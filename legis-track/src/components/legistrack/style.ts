import { TableRow } from "@mui/material";
import styled from "styled-components";

export const MainContainer = styled.div`
  display: flex;
  flex-direction: column;
  gap: 64px;
`

export const TitleContainer = styled.div`
  width: 100%;
  margin: 0 auto;
  color: #dfdfdf;
  background-color: #281c54;
  padding: 16px 0;
  letter-spacing: 2px;
  font-size: 1.5rem;

  h1 {
    text-align: center;
  }
`

export const ContentContainer = styled.div`
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 64px;
  margin-bottom: 64px;

  div {
    width: 100%;
    display: flex;
    flex-direction: column;
  }
`

export const StyledTableRow = styled(TableRow)`
  &:nth-of-type(odd) {
    background-color:rgb(246, 246, 255);
  }

  &:last-child td, &:last-child th {
    border: 0;
  }

  &:hover {
    background-color:rgb(229, 229, 253);
  }
`

export const StyledTableRowHead = styled(TableRow)`
  background-color: #281c54;
  
  th {
    color: #dfdfdf;
    font-weight: 600;
    font-size: 1rem;
  }
`