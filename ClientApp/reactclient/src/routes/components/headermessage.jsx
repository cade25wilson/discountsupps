import PropTypes from 'prop-types';
import { useLocation } from 'react-router-dom';

function HeaderMessage({ totalProducts }) {
    const location = useLocation();
    const query = new URLSearchParams(location.search);

    const brand = query.get('brand');
    const search = query.get('search');

    return (
        <div className="col col-lg-6 col-4">
            {brand && <h2 className="mb-2">Showing results for {brand}</h2>}
            {search && <h2 className="mb-2">Search results for {search}</h2>}
            {!brand && !search && <p className="mb-0">{totalProducts} total results</p>}
        </div>
    );
}

HeaderMessage.propTypes = {
    totalProducts: PropTypes.number,
};

export default HeaderMessage;