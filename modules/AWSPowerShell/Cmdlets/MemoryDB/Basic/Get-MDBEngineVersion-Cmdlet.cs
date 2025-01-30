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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Returns a list of the available Redis OSS engine versions.
    /// </summary>
    [Cmdlet("Get", "MDBEngineVersion")]
    [OutputType("Amazon.MemoryDB.Model.EngineVersionInfo")]
    [AWSCmdlet("Calls the Amazon MemoryDB DescribeEngineVersions API operation.", Operation = new[] {"DescribeEngineVersions"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.DescribeEngineVersionsResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.EngineVersionInfo or Amazon.MemoryDB.Model.DescribeEngineVersionsResponse",
        "This cmdlet returns a collection of Amazon.MemoryDB.Model.EngineVersionInfo objects.",
        "The service call response (type Amazon.MemoryDB.Model.DescribeEngineVersionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMDBEngineVersionCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefaultOnly
        /// <summary>
        /// <para>
        /// <para>If true, specifies that only the default version of the specified engine or engine
        /// and major version combination is to be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DefaultOnly { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the engine for which to list available versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The Redis OSS engine version</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter ParameterGroupFamily
        /// <summary>
        /// <para>
        /// <para>The name of a specific parameter group family to return details for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParameterGroupFamily { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in the response. If more records exist than
        /// the specified MaxResults value, a token is included in the response so that the remaining
        /// results can be retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An optional argument to pass in case the total number of records exceeds the value
        /// of MaxResults. If nextToken is returned, there are more results available. The value
        /// of nextToken is a unique pagination token for each page. Make the call again using
        /// the returned token to retrieve the next page. Keep all other arguments unchanged.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EngineVersions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.DescribeEngineVersionsResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.DescribeEngineVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EngineVersions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EngineVersion parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EngineVersion' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EngineVersion' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.DescribeEngineVersionsResponse, GetMDBEngineVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EngineVersion;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultOnly = this.DefaultOnly;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ParameterGroupFamily = this.ParameterGroupFamily;
            
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
            var request = new Amazon.MemoryDB.Model.DescribeEngineVersionsRequest();
            
            if (cmdletContext.DefaultOnly != null)
            {
                request.DefaultOnly = cmdletContext.DefaultOnly.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ParameterGroupFamily != null)
            {
                request.ParameterGroupFamily = cmdletContext.ParameterGroupFamily;
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
        
        private Amazon.MemoryDB.Model.DescribeEngineVersionsResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.DescribeEngineVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "DescribeEngineVersions");
            try
            {
                #if DESKTOP
                return client.DescribeEngineVersions(request);
                #elif CORECLR
                return client.DescribeEngineVersionsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DefaultOnly { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ParameterGroupFamily { get; set; }
            public System.Func<Amazon.MemoryDB.Model.DescribeEngineVersionsResponse, GetMDBEngineVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EngineVersions;
        }
        
    }
}
