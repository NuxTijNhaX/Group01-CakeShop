import { endpoint, addressAPI } from "./config.js";

export const getProduct = async (id) => {
    try {
        const response = await fetch(`${endpoint}/Product/${id}`);

        if(!response || !response.ok) {
            throw new Error(response.title);
        }

        return await response.json();
    } catch (error) {
        console.log("getProduct: " + error);
        return { error: error.message };
    }
}

export const getTrendingProduct = async () => {
    try {
        const response = await fetch(`${endpoint}/Product/trending`);

        if(!response || !response.ok) {
            throw new Error(response.title);
        }

        return await response.json();
    } catch (error) {
        console.log("getProduct: " + error);
        return { error: error.message };
    }
}

export const getNewReleaseProduct = async () => {
    try {
        const response = await fetch(`${endpoint}/Product/newProducts`);

        if(!response || !response.ok) {
            throw new Error(response.title);
        }

        return await response.json();
    } catch (error) {
        console.log("getProduct: " + error);
        return { error: error.message };
    }
}

export const getCategory = async () => {
    try {
        const response = await fetch(`${endpoint}/Category`);

        if(!response || !response.ok) {
            throw new Error(response.title);
        }

        return await response.json();
    } catch (error) {
        console.log("getCategory: " + error);
        return { error: error.message };
    }
}

export const getProducts = async (search = "", category = "", orderBy = "", page = 1) => {
    try {
        const response = await fetch(`${endpoint}/Product?search=${search}&category=${category}&orderBy=${orderBy}&page=${page}`);

        if(!response || !response.ok) {
            throw new Error(response.title);
        }

        return await response.json();
    } catch (error) {
        console.log("getProduct: " + error);
        return { error: error.message };
    }
}

export const signin = async ({ phone, password }) => {
    try {
        const response = await fetch(`${endpoint}/User?phone=${phone}&password=${password}`);

        if(response.status !== 200) {
            throw new Error("T??i kho???n ho???c m???t kh???u kh??ng ????ng");
        }

        return await response.json();
    } 
    catch (err) {
        console.log(err);
        return { error: err.message };
    }
};
  
export const register = async ({ name, phoneNumber, password }) => {
    try {
        const response = await fetch(`${endpoint}/User/register?name=${name}&phone=${phoneNumber}&password=${password}`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json; charset=utf-8'
            }
        });
    
        if (response.status !== 200) {
                throw new Error("L???i");
        }
        return await response.text();
    }
    catch (err) {
        console.log(err);
        return { error: err.message };
    }
};

export const createOrder = async (order) => {
    try {
        const response = await fetch(`${endpoint}/Order`, {
            method: 'POST',
            headers: {
            'Content-Type': 'application/json; charset=utf-8'
            },
            body: JSON.stringify(order)
        });
    
        if (response.status !== 200) {
                throw new Error("L???i");
        }

        return await response.json();
    }
    catch (err) {
        console.log(err);
        return { error: err.message };
    }
};

export const getProvice = async (value) => {
    try {
        const response = await fetch(`${addressAPI}/${value}`);
    
        if (response.status !== 200) {
                throw new Error("L???i");
        }

        return await response.json();
    }
    catch (err) {
        console.log(err);
        return { error: err.message };
    }
};