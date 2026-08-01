import { Routes, Route } from "react-router-dom";
import Register from "../pages/Register";
import Perfil from "../pages/Perfil";
import Login from "../pages/Login";
import Movimentacoes from "../pages/Movimentacoes";
import Produtos from "../pages/Produtos";
import Dashboard from "../pages/Dashboard";


export const AppRoutes = () => {
    return (
        <Routes>
            <Route path="/" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/dashboard" element={<Dashboard />} />
            <Route path="/produtos" element={<Produtos />} />
            <Route path="/movimentacoes" element={<Movimentacoes />} />
            <Route path="/perfil" element={<Perfil />} />
        </Routes>
    )
}