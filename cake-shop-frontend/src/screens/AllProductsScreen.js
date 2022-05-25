import ProductCard from "../components/ProductCard.js";
import Pagination from "../components/Pagination.js";
import { getProducts } from "../api.js";
import { parseRequestUrl } from "../utils.js";

const AllProductScreen = {
    render: async () => {
        const request = parseRequestUrl();
        let products = null;

        if(request.verb == "default") {
            products = await getProducts("", "", "", request.id);
        } 
        else {
            products = await getProducts("", "", request.verb, request.id);
        }

        return `
            <div class="small-container">

            <div class="row row-2">
                <h2>Tất cả bánh</h2>
                <select id="order-by">
                    <option selected value="default">Mặc định</option>
                    <option value="price_asc">Theo giá tăng</option>
                    <option value="price_desc">Theo giá giảm</option>
                    <option value="rating_asc">Theo đánh giá tăng</option>
                    <option value="rating_desc">Theo đánh giá giảm</option>
                    <option value="numOfPur_asc">Theo lượt mua tăng</option>
                    <option value="numOfPur_desc">Theo lượt mua giảm</option>
                </select>
            </div>

            <div class="row all-products-list">
                ${products.map(product => ProductCard.render(product)).join('')}
            </div>

            <div class="page-btn">
                <span>&#8592;</span>
                ${Pagination.render(window.location.hash, products[0].totalPage)}
                <span>&#8594;</span>
            </div>
        </div>
        `
    },
    after_render: () => {
        const request = parseRequestUrl();
        const paginations = document.getElementsByClassName("pagination");
        Array.from(paginations).forEach(pagination => {
            if(pagination.getAttribute("value") === request.id) {
                pagination.classList.add("active-pagination");
            } 
            else {
                pagination.classList.remove("active-pagination");
            }
        });

        const orderBy = document.getElementById("order-by");
        orderBy.addEventListener('change', () => {
            window.location.hash = '/' + [request.resource, request.id, orderBy.value].join('/');
        });
        orderBy.value = request.verb;
    }
}

export default AllProductScreen;