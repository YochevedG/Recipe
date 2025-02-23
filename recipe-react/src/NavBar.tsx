import { NavLink } from 'react-router-dom';

export default function NavBar() {
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <a className="navbar-brand" href="#">
                    <img src="/images/recipe.jpg" alt="" width="100" className="d-inline-block pe-3" />
                    Hearty Hearth
                </a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <NavLink className="nav-link" to="/recipes">Recipes</NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink className="nav-link" to="/meals">Meals</NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink className="nav-link" to="/cookbooks">Cookbooks</NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}