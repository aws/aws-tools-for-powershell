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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Retrieves version information for an IPAM prefix list resolver.
    /// 
    ///  
    /// <para>
    /// Each version is a snapshot of what CIDRs matched your rules at that moment in time.
    /// The version number increments every time the CIDR list changes due to infrastructure
    /// changes.
    /// </para><para><b>Version example:</b></para><para><b>Initial State (Version 1)</b></para><para>
    /// Production environment:
    /// </para><ul><li><para>
    /// vpc-prod-web (10.1.0.0/16) - tagged env=prod
    /// </para></li><li><para>
    /// vpc-prod-db (10.2.0.0/16) - tagged env=prod
    /// </para></li></ul><para>
    /// Resolver rule: Include all VPCs tagged env=prod
    /// </para><para><b>Version 1 CIDRs:</b> 10.1.0.0/16, 10.2.0.0/16
    /// </para><para><b>Infrastructure Change (Version 2)</b></para><para>
    /// New VPC added:
    /// </para><ul><li><para>
    /// vpc-prod-api (10.3.0.0/16) - tagged env=prod
    /// </para></li></ul><para>
    /// IPAM automatically detects the change and creates a new version.
    /// </para><para><b>Version 2 CIDRs:</b> 10.1.0.0/16, 10.2.0.0/16, 10.3.0.0/16
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2IpamPrefixListResolverVersion")]
    [OutputType("Amazon.EC2.Model.IpamPrefixListResolverVersion")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetIpamPrefixListResolverVersions API operation.", Operation = new[] {"GetIpamPrefixListResolverVersions"}, SelectReturnType = typeof(Amazon.EC2.Model.GetIpamPrefixListResolverVersionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamPrefixListResolverVersion or Amazon.EC2.Model.GetIpamPrefixListResolverVersionsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.IpamPrefixListResolverVersion objects.",
        "The service call response (type Amazon.EC2.Model.GetIpamPrefixListResolverVersionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2IpamPrefixListResolverVersionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters to limit the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter IpamPrefixListResolverId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM prefix list resolver whose versions you want to retrieve.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String IpamPrefixListResolverId { get; set; }
        #endregion
        
        #region Parameter IpamPrefixListResolverVersion
        /// <summary>
        /// <para>
        /// <para>Specific version numbers to retrieve. If not specified, all versions are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IpamPrefixListResolverVersions")]
        public System.Int64[] IpamPrefixListResolverVersion { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. To get the next page of items,
        /// make another request with the token returned in the output. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Query-Requests.html#api-pagination">Pagination</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamPrefixListResolverVersions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetIpamPrefixListResolverVersionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetIpamPrefixListResolverVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamPrefixListResolverVersions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IpamPrefixListResolverId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IpamPrefixListResolverId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IpamPrefixListResolverId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetIpamPrefixListResolverVersionsResponse, GetEC2IpamPrefixListResolverVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IpamPrefixListResolverId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.IpamPrefixListResolverId = this.IpamPrefixListResolverId;
            #if MODULAR
            if (this.IpamPrefixListResolverId == null && ParameterWasBound(nameof(this.IpamPrefixListResolverId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPrefixListResolverId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.IpamPrefixListResolverVersion != null)
            {
                context.IpamPrefixListResolverVersion = new List<System.Int64>(this.IpamPrefixListResolverVersion);
            }
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.GetIpamPrefixListResolverVersionsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.IpamPrefixListResolverId != null)
            {
                request.IpamPrefixListResolverId = cmdletContext.IpamPrefixListResolverId;
            }
            if (cmdletContext.IpamPrefixListResolverVersion != null)
            {
                request.IpamPrefixListResolverVersions = cmdletContext.IpamPrefixListResolverVersion;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
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
                    
                    _nextToken = response.NextToken;
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
        
        private Amazon.EC2.Model.GetIpamPrefixListResolverVersionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetIpamPrefixListResolverVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetIpamPrefixListResolverVersions");
            try
            {
                #if DESKTOP
                return client.GetIpamPrefixListResolverVersions(request);
                #elif CORECLR
                return client.GetIpamPrefixListResolverVersionsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.String IpamPrefixListResolverId { get; set; }
            public List<System.Int64> IpamPrefixListResolverVersion { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.EC2.Model.GetIpamPrefixListResolverVersionsResponse, GetEC2IpamPrefixListResolverVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamPrefixListResolverVersions;
        }
        
    }
}
