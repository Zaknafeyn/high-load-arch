-- select all items from imported table
SELECT * 
FROM HW9.movies t
WHERE t.`Year` = 0
WHERE genres LIKE '%listed%'
--WHERE t.Title = '#VALUE!'


-- convert table data to json format for bulk insert
SELECT CONCAT(st.queryDescr, "\n","{", st.id, ", ", st.title, ", ", st.year, ", ", st.genres, " }")
FROM (
			SELECT CONCAT("""id"": ", t.Id) id,
			       CONCAT("""title"": """, t.Title, """" ) title,
			       CONCAT("""year"": ", t.Year ) year,
					 CONCAT("""genre"": [""" ,  REPLACE(t.Genres, '|', '", "'), """]") genres,
					 CONCAT("{ ""create"" : { ""_index"" : ""movies"", ""_id"" : """, t.Id ,""" } }") AS queryDescr
			FROM HW9.movies t
--			ORDER BY ID DESC
--			LIMIT 20 OFFSET 0
	  ) AS st