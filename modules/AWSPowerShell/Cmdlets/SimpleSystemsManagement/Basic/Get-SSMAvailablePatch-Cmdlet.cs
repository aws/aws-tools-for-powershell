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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Lists all patches eligible to be included in a patch baseline.
    /// 
    ///  <note><para>
    /// Currently, <c>DescribeAvailablePatches</c> supports only the Amazon Linux 1, Amazon
    /// Linux 2, and Windows Server operating systems.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SSMAvailablePatch")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.Patch")]
    [AWSCmdlet("Calls the AWS Systems Manager DescribeAvailablePatches API operation.", Operation = new[] {"DescribeAvailablePatches"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.Patch or Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesResponse",
        "This cmdlet returns a collection of Amazon.SimpleSystemsManagement.Model.Patch objects.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSMAvailablePatchCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Each element in the array is a structure containing a key-value pair.</para><para><b>Windows Server</b></para><para>Supported keys for Windows Server managed node patches include the following:</para><ul><li><para><b><c>PATCH_SET</c></b></para><para>Sample values: <c>OS</c> | <c>APPLICATION</c></para></li><li><para><b><c>PRODUCT</c></b></para><para>Sample values: <c>WindowsServer2012</c> | <c>Office 2010</c> | <c>MicrosoftDefenderAntivirus</c></para></li><li><para><b><c>PRODUCT_FAMILY</c></b></para><para>Sample values: <c>Windows</c> | <c>Office</c></para></li><li><para><b><c>MSRC_SEVERITY</c></b></para><para>Sample values: <c>ServicePacks</c> | <c>Important</c> | <c>Moderate</c></para></li><li><para><b><c>CLASSIFICATION</c></b></para><para>Sample values: <c>ServicePacks</c> | <c>SecurityUpdates</c> | <c>DefinitionUpdates</c></para></li><li><para><b><c>PATCH_ID</c></b></para><para>Sample values: <c>KB123456</c> | <c>KB4516046</c></para></li></ul><para><b>Linux</b></para><important><para>When specifying filters for Linux patches, you must specify a key-pair for <c>PRODUCT</c>.
        /// For example, using the Command Line Interface (CLI), the following command fails:</para><para><c>aws ssm describe-available-patches --filters Key=CVE_ID,Values=CVE-2018-3615</c></para><para>However, the following command succeeds:</para><para><c>aws ssm describe-available-patches --filters Key=PRODUCT,Values=AmazonLinux2018.03
        /// Key=CVE_ID,Values=CVE-2018-3615</c></para></important><para>Supported keys for Linux managed node patches include the following:</para><ul><li><para><b><c>PRODUCT</c></b></para><para>Sample values: <c>AmazonLinux2018.03</c> | <c>AmazonLinux2.0</c></para></li><li><para><b><c>NAME</c></b></para><para>Sample values: <c>kernel-headers</c> | <c>samba-python</c> | <c>php</c></para></li><li><para><b><c>SEVERITY</c></b></para><para>Sample values: <c>Critical</c> | <c>Important</c> | <c>Medium</c> | <c>Low</c></para></li><li><para><b><c>EPOCH</c></b></para><para>Sample values: <c>0</c> | <c>1</c></para></li><li><para><b><c>VERSION</c></b></para><para>Sample values: <c>78.6.1</c> | <c>4.10.16</c></para></li><li><para><b><c>RELEASE</c></b></para><para>Sample values: <c>9.56.amzn1</c> | <c>1.amzn2</c></para></li><li><para><b><c>ARCH</c></b></para><para>Sample values: <c>i686</c> | <c>x86_64</c></para></li><li><para><b><c>REPOSITORY</c></b></para><para>Sample values: <c>Core</c> | <c>Updates</c></para></li><li><para><b><c>ADVISORY_ID</c></b></para><para>Sample values: <c>ALAS-2018-1058</c> | <c>ALAS2-2021-1594</c></para></li><li><para><b><c>CVE_ID</c></b></para><para>Sample values: <c>CVE-2018-3615</c> | <c>CVE-2020-1472</c></para></li><li><para><b><c>BUGZILLA_ID</c></b></para><para>Sample values: <c>1463241</c></para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.SimpleSystemsManagement.Model.PatchOrchestratorFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of patches to return (per page).</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>50</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of items to return. (You received this token from a previous
        /// call.)</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Patches'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Patches";
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
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesResponse, GetSSMAvailablePatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.SimpleSystemsManagement.Model.PatchOrchestratorFilter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteVerbose("MaxResult parameter unset, using default value of '50'");
                context.MaxResult = 50;
            }
            #endif
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesRequest();
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 50. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 50 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(50, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxResult)))
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(50);
                }
                
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
                    int _receivedThisCall = response.Patches?.Count ?? 0;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "DescribeAvailablePatches");
            try
            {
                return client.DescribeAvailablePatchesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleSystemsManagement.Model.PatchOrchestratorFilter> Filter { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.DescribeAvailablePatchesResponse, GetSSMAvailablePatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Patches;
        }
        
    }
}
