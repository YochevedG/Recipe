import { useState } from 'react'
import './assets/css/bootstrap.min.css'
import MainScreen from './MainScreen'
import Navbar from './NavBar'
import SideBar from './SideBar'

function App() {
  const [selectedcuisineid, setSelectedCuisineId] = useState(0);
  const handleCusineSelected = (cuisineId: number) => {
    setSelectedCuisineId(cuisineId);
  };
  return (
    <div className='container'>
      <div className="row">
        <div className="col-12 px-0">
          <Navbar />
        </div>
      </div>
      <div className="row">
        <div className="col-3 col-lg-2 border border-light">
          <SideBar onCuisineSelected={handleCusineSelected} />
        </div>
        <div className="col-9 col-lg-10 bg-primary">
          <MainScreen cuisineId={selectedcuisineid} />
        </div>
      </div>
    </div >
  )
}

export default App
