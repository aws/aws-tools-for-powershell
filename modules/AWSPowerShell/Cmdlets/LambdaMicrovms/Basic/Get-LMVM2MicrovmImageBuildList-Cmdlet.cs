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
using Amazon.LambdaMicrovms;
using Amazon.LambdaMicrovms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMVM2
{
    /// <summary>
    /// Lists builds for a MicroVM image version with optional filtering by architecture and
    /// chipset. We recommend using pagination to ensure that the operation returns quickly
    /// and successfully.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LMVM2MicrovmImageBuildList")]
    [OutputType("Amazon.LambdaMicrovms.Model.MicrovmImageBuildSummary")]
    [AWSCmdlet("Calls the Lambda MicroVMs ListMicrovmImageBuilds API operation.", Operation = new[] {"ListMicrovmImageBuilds"}, SelectReturnType = typeof(Amazon.LambdaMicrovms.Model.ListMicrovmImageBuildsResponse))]
    [AWSCmdletOutput("Amazon.LambdaMicrovms.Model.MicrovmImageBuildSummary or Amazon.LambdaMicrovms.Model.ListMicrovmImageBuildsResponse",
        "This cmdlet returns a collection of Amazon.LambdaMicrovms.Model.MicrovmImageBuildSummary objects.",
        "The service call response (type Amazon.LambdaMicrovms.Model.ListMicrovmImageBuildsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLMVM2MicrovmImageBuildListCmdlet : AmazonLambdaMicrovmsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>Filters builds by target CPU architecture.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaMicrovms.Architecture")]
        public Amazon.LambdaMicrovms.Architecture Architecture { get; set; }
        #endregion
        
        #region Parameter Chipset
        /// <summary>
        /// <para>
        /// <para>Filters builds by target chipset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaMicrovms.Chipset")]
        public Amazon.LambdaMicrovms.Chipset Chipset { get; set; }
        #endregion
        
        #region Parameter ChipsetGeneration
        /// <summary>
        /// <para>
        /// <para>Filters builds by target chipset generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChipsetGeneration { get; set; }
        #endregion
        
        #region Parameter ImageIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ARN or ID) of the MicroVM image.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ImageIdentifier { get; set; }
        #endregion
        
        #region Parameter ImageVersion
        /// <summary>
        /// <para>
        /// <para>The version of the MicroVM image to list builds for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ImageVersion { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token from a previous call. Use this token to retrieve the next page
        /// of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaMicrovms.Model.ListMicrovmImageBuildsResponse).
        /// Specifying the name of a property of type Amazon.LambdaMicrovms.Model.ListMicrovmImageBuildsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.LambdaMicrovms.Model.ListMicrovmImageBuildsResponse, GetLMVM2MicrovmImageBuildListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Architecture = this.Architecture;
            context.Chipset = this.Chipset;
            context.ChipsetGeneration = this.ChipsetGeneration;
            context.ImageIdentifier = this.ImageIdentifier;
            #if MODULAR
            if (this.ImageIdentifier == null && ParameterWasBound(nameof(this.ImageIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageVersion = this.ImageVersion;
            #if MODULAR
            if (this.ImageVersion == null && ParameterWasBound(nameof(this.ImageVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
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
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.LambdaMicrovms.Model.ListMicrovmImageBuildsRequest();
            
            if (cmdletContext.Architecture != null)
            {
                request.Architecture = cmdletContext.Architecture;
            }
            if (cmdletContext.Chipset != null)
            {
                request.Chipset = cmdletContext.Chipset;
            }
            if (cmdletContext.ChipsetGeneration != null)
            {
                request.ChipsetGeneration = cmdletContext.ChipsetGeneration;
            }
            if (cmdletContext.ImageIdentifier != null)
            {
                request.ImageIdentifier = cmdletContext.ImageIdentifier;
            }
            if (cmdletContext.ImageVersion != null)
            {
                request.ImageVersion = cmdletContext.ImageVersion;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LambdaMicrovms.Model.ListMicrovmImageBuildsResponse CallAWSServiceOperation(IAmazonLambdaMicrovms client, Amazon.LambdaMicrovms.Model.ListMicrovmImageBuildsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Lambda MicroVMs", "ListMicrovmImageBuilds");
            try
            {
                return client.ListMicrovmImageBuildsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.LambdaMicrovms.Architecture Architecture { get; set; }
            public Amazon.LambdaMicrovms.Chipset Chipset { get; set; }
            public System.String ChipsetGeneration { get; set; }
            public System.String ImageIdentifier { get; set; }
            public System.String ImageVersion { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.LambdaMicrovms.Model.ListMicrovmImageBuildsResponse, GetLMVM2MicrovmImageBuildListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
