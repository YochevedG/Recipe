import { useForm } from "react-hook-form";
import { useUserStore } from "./userstore";

type forminput = { username: string, password: string };

export default function Login() {
    const { register, handleSubmit, formState: { errors } } = useForm<forminput>();
    const login = useUserStore(state => state.login);
    const isLoggedIn = useUserStore(state => state.isLoggedin);
    const onSubmit = async (data: forminput) => await login(data.username, data.password);

    return (
        <div className="d-flex justify-content-center align-items-center vh-100 bg-light">
            <div className="card p-4 shadow" style={{ width: '400px' }}>
                <h3 className="text-center mb-4">Login</h3>
                <form onSubmit={handleSubmit(onSubmit)}>
                    <div className="mb-3">
                        <label className="form-label">Username</label>
                        <input
                            type="text"
                            className={`form-control ${errors.username ? 'is-invalid' : ''}`}
                            {...register('username', { required: 'Username is required' })}
                        />
                        {errors.username && <div className="invalid-feedback">{errors.username.message}</div>}
                    </div>
                    <div className="mb-3">
                        <label className="form-label">Password</label>
                        <input
                            type="password"
                            className={`form-control ${errors.password ? 'is-invalid' : ''}`}
                            {...register('password', { required: 'Password is required' })}
                        />
                        {errors.password && <div className="invalid-feedback">{errors.password.message}</div>}
                    </div>
                    <button type="submit" className="btn btn-primary w-100">Login</button>
                </form>
                <div className="text-center mt-3">
                    <small>Logged in: {isLoggedIn.toString()}</small>
                </div>
            </div>
        </div>
    );
}