import { useEffect, useState } from "react";
import { ICuisine } from "./DataInterfaces";
import { fetchCuisine } from "./DataUtil";
import CuisineButton from "./CuisineButton";

interface Props {
    onCuisineSelected: (cuisineId: number) => void;
}

export default function SideBar({ onCuisineSelected }: Props) {
    const [cusinelist, setCuisineList] = useState<ICuisine[]>([]);
    const [selectedCuisineId, setSelectedCuisineId] = useState(0);
    useEffect(() => {
        const fetchdata = async () => {
            const data = await fetchCuisine();
            setCuisineList(data);
            if (data.length > 0) {
                handleSelectedCuisine(data[0].cuisineId);
            }
        }
        fetchdata();
    }
        , [])
    function handleSelectedCuisine(cuisineId: number) {
        setSelectedCuisineId(cuisineId);
        onCuisineSelected(cuisineId);
    }
    return (
        <>
            <h2>{cusinelist.map(p => <CuisineButton key={p.cuisineId} cuisine={p} onSelected={handleSelectedCuisine} isSelected={p.cuisineId == selectedCuisineId} />)}</h2>
        </>
    )
}