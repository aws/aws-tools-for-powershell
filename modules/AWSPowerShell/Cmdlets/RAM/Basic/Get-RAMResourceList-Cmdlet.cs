/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.RAM;
using Amazon.RAM.Model;

namespace Amazon.PowerShell.Cmdlets.RAM
{
    /// <summary>
    /// Lists the resources that you added to a resource shares or the resources that are
    /// shared with you.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RAMResourceList")]
    [OutputType("Amazon.RAM.Model.Resource")]
    [AWSCmdlet("Calls the AWS Resource Access Manager (RAM) ListResources API operation.", Operation = new[] {"ListResources"}, SelectReturnType = typeof(Amazon.RAM.Model.ListResourcesResponse))]
    [AWSCmdletOutput("Amazon.RAM.Model.Resource or Amazon.RAM.Model.ListResourcesResponse",
        "This cmdlet returns a collection of Amazon.RAM.Model.Resource objects.",
        "The service call response (type Amazon.RAM.Model.ListResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRAMResourceListCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to list only the resource shares that are associated with
        /// the specified principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Principal { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to list only the resource shares that include resources with
        /// the specified <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter ResourceOwner
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to list only the resource shares that match the following:</para><ul><li><para><b><code>SELF</code></b> – resources that you are sharing</para></li><li><para><b><code>OTHER-ACCOUNTS</code></b> – resources that other accounts share with you</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.RAM.ResourceOwner")]
        public Amazon.RAM.ResourceOwner ResourceOwner { get; set; }
        #endregion
        
        #region Parameter ResourceRegionScope
        /// <summary>
        /// <para>
        /// <para>Specifies that you want the results to include only resources that have the specified
        /// scope.</para><ul><li><para><code>ALL</code> – the results include both global and regional resources or resource
        /// types.</para></li><li><para><code>GLOBAL</code> – the results include only global resources or resource types.</para></li><li><para><code>REGIONAL</code> – the results include only regional resources or resource types.</para></li></ul><para>The default value is <code>ALL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RAM.ResourceRegionScopeFilter")]
        public Amazon.RAM.ResourceRegionScopeFilter ResourceRegionScope { get; set; }
        #endregion
        
        #region Parameter ResourceShareArn
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to list only resources in the resource shares identified by
        /// the specified <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceShareArns")]
        public System.String[] ResourceShareArn { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to list only the resource shares that include resources of
        /// the specified resource type.</para><para>For valid values, query the <a>ListResourceTypes</a> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the total number of results that you want included on each page of the response.
        /// If you do not include this parameter, it defaults to a value that is specific to the
        /// operation. If additional items exist beyond the number you specify, the <code>NextToken</code>
        /// response element is returned with a value (not null). Include the specified value
        /// as the <code>NextToken</code> request parameter in the next call to the operation
        /// to get the next part of the results. Note that the service might return fewer results
        /// than the maximum even when there are more results available. You should check <code>NextToken</code>
        /// after every operation to ensure that you receive all of the results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>500</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to receive the next page of results. Valid only if you received
        /// a <code>NextToken</code> response in the previous request. If you did, it indicates
        /// that more output is available. Set this parameter to the value provided by the previous
        /// call's <code>NextToken</code> response to request the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Resources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RAM.Model.ListResourcesResponse).
        /// Specifying the name of a property of type Amazon.RAM.Model.ListResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Resources";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceOwner parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceOwner' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceOwner' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RAM.Model.ListResourcesResponse, GetRAMResourceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceOwner;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteVerbose("MaxResult parameter unset, using default value of '500'");
                context.MaxResult = 500;
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
            context.Principal = this.Principal;
            if (this.ResourceArn != null)
            {
                context.ResourceArn = new List<System.String>(this.ResourceArn);
            }
            context.ResourceOwner = this.ResourceOwner;
            #if MODULAR
            if (this.ResourceOwner == null && ParameterWasBound(nameof(this.ResourceOwner)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceOwner which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceRegionScope = this.ResourceRegionScope;
            if (this.ResourceShareArn != null)
            {
                context.ResourceShareArn = new List<System.String>(this.ResourceShareArn);
            }
            context.ResourceType = this.ResourceType;
            
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.RAM.Model.ListResourcesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            if (cmdletContext.ResourceOwner != null)
            {
                request.ResourceOwner = cmdletContext.ResourceOwner;
            }
            if (cmdletContext.ResourceRegionScope != null)
            {
                request.ResourceRegionScope = cmdletContext.ResourceRegionScope;
            }
            if (cmdletContext.ResourceShareArn != null)
            {
                request.ResourceShareArns = cmdletContext.ResourceShareArn;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.RAM.Model.ListResourcesRequest();
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            if (cmdletContext.ResourceOwner != null)
            {
                request.ResourceOwner = cmdletContext.ResourceOwner;
            }
            if (cmdletContext.ResourceRegionScope != null)
            {
                request.ResourceRegionScope = cmdletContext.ResourceRegionScope;
            }
            if (cmdletContext.ResourceShareArn != null)
            {
                request.ResourceShareArns = cmdletContext.ResourceShareArn;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
                // The service has a maximum page size of 500. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 500 items back. If a page size is set, that will
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
                    int correctPageSize = Math.Min(500, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxResult)))
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(500);
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
                    int _receivedThisCall = response.Resources.Count;
                    
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
        
        private Amazon.RAM.Model.ListResourcesResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.ListResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager (RAM)", "ListResources");
            try
            {
                #if DESKTOP
                return client.ListResources(request);
                #elif CORECLR
                return client.ListResourcesAsync(request).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Principal { get; set; }
            public List<System.String> ResourceArn { get; set; }
            public Amazon.RAM.ResourceOwner ResourceOwner { get; set; }
            public Amazon.RAM.ResourceRegionScopeFilter ResourceRegionScope { get; set; }
            public List<System.String> ResourceShareArn { get; set; }
            public System.String ResourceType { get; set; }
            public System.Func<Amazon.RAM.Model.ListResourcesResponse, GetRAMResourceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Resources;
        }
        
    }
}
