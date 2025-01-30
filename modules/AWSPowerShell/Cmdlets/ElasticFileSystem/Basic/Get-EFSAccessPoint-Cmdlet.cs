/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Returns the description of a specific Amazon EFS access point if the <c>AccessPointId</c>
    /// is provided. If you provide an EFS <c>FileSystemId</c>, it returns descriptions of
    /// all access points for that file system. You can provide either an <c>AccessPointId</c>
    /// or a <c>FileSystemId</c> in the request, but not both. 
    /// 
    ///  
    /// <para>
    /// This operation requires permissions for the <c>elasticfilesystem:DescribeAccessPoints</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EFSAccessPoint")]
    [OutputType("Amazon.ElasticFileSystem.Model.AccessPointDescription")]
    [AWSCmdlet("Calls the Amazon Elastic File System DescribeAccessPoints API operation.", Operation = new[] {"DescribeAccessPoints"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.DescribeAccessPointsResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.AccessPointDescription or Amazon.ElasticFileSystem.Model.DescribeAccessPointsResponse",
        "This cmdlet returns a collection of Amazon.ElasticFileSystem.Model.AccessPointDescription objects.",
        "The service call response (type Amazon.ElasticFileSystem.Model.DescribeAccessPointsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEFSAccessPointCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessPointId
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies an EFS access point to describe in the response; mutually exclusive
        /// with <c>FileSystemId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessPointId { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>(Optional) If you provide a <c>FileSystemId</c>, EFS returns all access points for
        /// that file system; mutually exclusive with <c>AccessPointId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>(Optional) When retrieving all access points for a file system, you can optionally
        /// specify the <c>MaxItems</c> parameter to limit the number of objects returned in a
        /// response. The default value is 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para><c>NextToken</c> is present if the response is paginated. You can use <c>NextMarker</c>
        /// in the subsequent request to fetch the next page of access point descriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccessPoints'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.DescribeAccessPointsResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.DescribeAccessPointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccessPoints";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FileSystemId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FileSystemId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FileSystemId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.DescribeAccessPointsResponse, GetEFSAccessPointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FileSystemId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessPointId = this.AccessPointId;
            context.FileSystemId = this.FileSystemId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticFileSystem.Model.DescribeAccessPointsRequest();
            
            if (cmdletContext.AccessPointId != null)
            {
                request.AccessPointId = cmdletContext.AccessPointId;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ElasticFileSystem.Model.DescribeAccessPointsResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.DescribeAccessPointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "DescribeAccessPoints");
            try
            {
                #if DESKTOP
                return client.DescribeAccessPoints(request);
                #elif CORECLR
                return client.DescribeAccessPointsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AccessPointId { get; set; }
            public System.String FileSystemId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.DescribeAccessPointsResponse, GetEFSAccessPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccessPoints;
        }
        
    }
}
