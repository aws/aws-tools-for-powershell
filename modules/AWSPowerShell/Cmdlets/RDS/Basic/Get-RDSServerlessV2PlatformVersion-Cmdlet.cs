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
using System.Threading;
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Describes the properties of specific platform versions for Aurora Serverless v2.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RDSServerlessV2PlatformVersion")]
    [OutputType("Amazon.RDS.Model.ServerlessV2PlatformVersionInfo")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeServerlessV2PlatformVersions API operation.", Operation = new[] {"DescribeServerlessV2PlatformVersions"}, SelectReturnType = typeof(Amazon.RDS.Model.DescribeServerlessV2PlatformVersionsResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.ServerlessV2PlatformVersionInfo or Amazon.RDS.Model.DescribeServerlessV2PlatformVersionsResponse",
        "This cmdlet returns a collection of Amazon.RDS.Model.ServerlessV2PlatformVersionInfo objects.",
        "The service call response (type Amazon.RDS.Model.DescribeServerlessV2PlatformVersionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRDSServerlessV2PlatformVersionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DefaultOnly
        /// <summary>
        /// <para>
        /// <para>Specifies whether to return only the default platform versions for each engine. The
        /// default platform version is the version used for new DB clusters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DefaultOnly { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine to return platform version details for.</para><para>Valid Values:</para><ul><li><para><c>aurora-mysql</c></para></li><li><para><c>aurora-postgresql</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>This parameter isn't currently supported.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter IncludeAll
        /// <summary>
        /// <para>
        /// <para>Specifies whether to also include platform versions which are no longer in use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeAll { get; set; }
        #endregion
        
        #region Parameter ServerlessV2PlatformVersion
        /// <summary>
        /// <para>
        /// <para>A specific platform version to return details for.</para><para>Example: <c>3</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerlessV2PlatformVersion { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the marker, up to the value specified
        /// by <c>MaxRecords</c>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in the response. If more than the <c>MaxRecords</c>
        /// value is available, a pagination token called a marker is included in the response
        /// so you can retrieve the remaining results.</para><para>Default: 20</para><para>Constraints: Minimum 1, maximum 200.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxRecords")]
        public int? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerlessV2PlatformVersions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DescribeServerlessV2PlatformVersionsResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DescribeServerlessV2PlatformVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerlessV2PlatformVersions";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DescribeServerlessV2PlatformVersionsResponse, GetRDSServerlessV2PlatformVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefaultOnly = this.DefaultOnly;
            context.Engine = this.Engine;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.RDS.Model.Filter>(this.Filter);
            }
            context.IncludeAll = this.IncludeAll;
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxRecord)) && this.MaxRecord.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxRecord parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxRecord" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.ServerlessV2PlatformVersion = this.ServerlessV2PlatformVersion;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.RDS.Model.DescribeServerlessV2PlatformVersionsRequest();
            
            if (cmdletContext.DefaultOnly != null)
            {
                request.DefaultOnly = cmdletContext.DefaultOnly.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.IncludeAll != null)
            {
                request.IncludeAll = cmdletContext.IncludeAll.Value;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecord.Value);
            }
            if (cmdletContext.ServerlessV2PlatformVersion != null)
            {
                request.ServerlessV2PlatformVersion = cmdletContext.ServerlessV2PlatformVersion;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.Marker;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.RDS.Model.DescribeServerlessV2PlatformVersionsResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeServerlessV2PlatformVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeServerlessV2PlatformVersions");
            try
            {
                return client.DescribeServerlessV2PlatformVersionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.RDS.Model.Filter> Filter { get; set; }
            public System.Boolean? IncludeAll { get; set; }
            public System.String Marker { get; set; }
            public int? MaxRecord { get; set; }
            public System.String ServerlessV2PlatformVersion { get; set; }
            public System.Func<Amazon.RDS.Model.DescribeServerlessV2PlatformVersionsResponse, GetRDSServerlessV2PlatformVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerlessV2PlatformVersions;
        }
        
    }
}
