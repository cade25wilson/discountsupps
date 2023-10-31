import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';

function ProductLayout({product}) {
    if(!product) return (<div>Loading...</div>);
    return (
        <div className="border rounded p-3 h-100">
            {/* <ProductImage :image="product.supplement.image" :url="product.url"/> */}
            <div className="product-name h-auto">
                <h5>{product.supplement.name}</h5>
                <div className="row h-auto">
                    <div className="col-3">
                        <div className="product-price">
                            <p> 
                                <span className="text-danger"><del>{product.supplement.originalPrice}</del></span>
                                $ {product.supplement.discountPrice}
                            </p>
                        </div>
                    </div>
                    <div className="col-9">
                        <div className="product-brand text-end">
                            {product.brand &&
                            <Link to={`/brand?brand=${product.brand.brandUrl}`} className="text-black">
                                <p className="mb-0">{product.brand.brandName}</p>
                            </Link>
                            }
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-3">
                        <p>${product.supplement.discount}🔻</p>
                    </div>
                    <div className="col-9 text-end">
                        <a href="/" className="text-black">
                            <p>{product.supplement.advertiser}</p>
                        </a>
                    </div>
                </div>
                <div className="row">
                    <div className="text-center">
                        <a href={product.supplement.url} className="btn btn-primary w-75" target="_blank" rel="noopener noreferrer">View Product</a>
                    </div>
                </div>
            </div>
        </div>
    );
}

ProductLayout.propTypes = {
    product: PropTypes.shape({
        supplement: PropTypes.shape({
            name: PropTypes.string,
            originalPrice: PropTypes.number,
            discountPrice: PropTypes.number,
            discount: PropTypes.number,
            advertiser: PropTypes.string,
            url: PropTypes.string,
        }),
        brand: PropTypes.shape({
            brandUrl: PropTypes.string,
            brandName: PropTypes.string,
        }),
    }).isRequired,
};

export default ProductLayout;