using System.Collections.Generic;
using ClassLibrary;
using Instagramp_2.Models;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

public interface IPostDAO
{
    Task Create(PostModel post);
    PostModel GetById(string id);

    List<PostModel> GetAll();
    public void Update(string id, PostModel post);

    public void Delete(string id);
}
