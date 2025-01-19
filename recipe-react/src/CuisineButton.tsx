import { ICuisine } from "./DataInterfaces";

interface Props {
    cuisine: ICuisine
    isSelected: boolean
    onSelected: (cuisineId: number) => (void)
}

export default function CuisineButton({ cuisine, isSelected, onSelected }: Props) {
    return (
        <div onClick={() => onSelected(cuisine.cuisineId)} className={`btn ${isSelected ? "bg-secondary" : ""}`}>
            <figure className="figure">
                <img src={`/images/cuisine-images/${cuisine.cuisineType}.jpg`} className="figure-img img-fluid rounded" alt="..." />
                <figcaption className="figure-caption text-center">{cuisine.cuisineType}</figcaption>
            </figure>
        </div>
    )
}