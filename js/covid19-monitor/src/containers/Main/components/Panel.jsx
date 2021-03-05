import React, { memo } from 'react';
import {Card, Typography,  Select, MenuItem } from '../../../components';
import COUNTRIES from '../../../commons/constants/countries';
import {CardPanelContentStyled, ItemStyled } from './style';


function Panel({ updateAt, onChange, data, country, getCoviddata }) {
  const {cases, recovered, deaths, todayCases, todayDeaths} = data

  const renderCountries = (country, index) => (
    <MenuItem key={`country-${index}`} value={country.value}>
      <ItemStyled>
        <div>{country.label}</div>
        <img src={country.flag} alt={`País-${country.label}`} />
      </ItemStyled>
    </MenuItem>
  )

  return (
    <Card>
      <CardPanelContentStyled>
        <div>
          <Typography variant="h3" component="span" color="black">COVID19 - Monitor</Typography>
          <div className="pt-2">
            <Select onChange={onChange} value={country}>
              {COUNTRIES.map(renderCountries)}
            </Select>
          </div>
        </div>        
      </CardPanelContentStyled>
    </Card>
  )
}

export default memo(Panel);