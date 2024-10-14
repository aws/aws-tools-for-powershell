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
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;

namespace Amazon.PowerShell.Cmdlets.PINE
{
    /// <summary>
    /// Retrieve deliverability data for all the campaigns that used a specific domain to
    /// send email during a specified time range. This data is available for a domain only
    /// if you enabled the Deliverability dashboard (<c>PutDeliverabilityDashboardOption</c>
    /// operation) for the domain.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "PINEDomainDeliverabilityCampaignList")]
    [OutputType("Amazon.PinpointEmail.Model.DomainDeliverabilityCampaign")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email ListDomainDeliverabilityCampaigns API operation.", Operation = new[] {"ListDomainDeliverabilityCampaigns"}, SelectReturnType = typeof(Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsResponse))]
    [AWSCmdletOutput("Amazon.PinpointEmail.Model.DomainDeliverabilityCampaign or Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsResponse",
        "This cmdlet returns a collection of Amazon.PinpointEmail.Model.DomainDeliverabilityCampaign objects.",
        "The service call response (type Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPINEDomainDeliverabilityCampaignListCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The last day, in Unix time format, that you want to obtain deliverability data for.
        /// This value has to be less than or equal to 30 days after the value of the <c>StartDate</c>
        /// parameter.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndDate { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>The first day, in Unix time format, that you want to obtain deliverability data for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartDate { get; set; }
        #endregion
        
        #region Parameter SubscribedDomain
        /// <summary>
        /// <para>
        /// <para>The domain to obtain deliverability data for.</para>
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
        public System.String SubscribedDomain { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token that’s returned from a previous call to the <c>ListDomainDeliverabilityCampaigns</c>
        /// operation. This token indicates the position of a campaign in the list of campaigns.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to include in response to a single call to the <c>ListDomainDeliverabilityCampaigns</c>
        /// operation. If the number of results is larger than the number that you specify in
        /// this parameter, the response includes a <c>NextToken</c> element, which you can use
        /// to obtain additional results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainDeliverabilityCampaigns'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsResponse).
        /// Specifying the name of a property of type Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainDeliverabilityCampaigns";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SubscribedDomain parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SubscribedDomain' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SubscribedDomain' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsResponse, GetPINEDomainDeliverabilityCampaignListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SubscribedDomain;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndDate = this.EndDate;
            #if MODULAR
            if (this.EndDate == null && ParameterWasBound(nameof(this.EndDate)))
            {
                WriteWarning("You are passing $null as a value for parameter EndDate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.PageSize = this.PageSize;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.PageSize)) && this.PageSize.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the PageSize parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing PageSize" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.StartDate = this.StartDate;
            #if MODULAR
            if (this.StartDate == null && ParameterWasBound(nameof(this.StartDate)))
            {
                WriteWarning("You are passing $null as a value for parameter StartDate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubscribedDomain = this.SubscribedDomain;
            #if MODULAR
            if (this.SubscribedDomain == null && ParameterWasBound(nameof(this.SubscribedDomain)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscribedDomain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsRequest();
            
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.PageSize.Value);
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate.Value;
            }
            if (cmdletContext.SubscribedDomain != null)
            {
                request.SubscribedDomain = cmdletContext.SubscribedDomain;
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
            var request = new Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsRequest();
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate.Value;
            }
            if (cmdletContext.SubscribedDomain != null)
            {
                request.SubscribedDomain = cmdletContext.SubscribedDomain;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PageSize.HasValue)
            {
                _emitLimit = cmdletContext.PageSize;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.PageSize = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
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
                    int _receivedThisCall = response.DomainDeliverabilityCampaigns.Count;
                    
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
        
        private Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "ListDomainDeliverabilityCampaigns");
            try
            {
                #if DESKTOP
                return client.ListDomainDeliverabilityCampaigns(request);
                #elif CORECLR
                return client.ListDomainDeliverabilityCampaignsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndDate { get; set; }
            public System.String NextToken { get; set; }
            public int? PageSize { get; set; }
            public System.DateTime? StartDate { get; set; }
            public System.String SubscribedDomain { get; set; }
            public System.Func<Amazon.PinpointEmail.Model.ListDomainDeliverabilityCampaignsResponse, GetPINEDomainDeliverabilityCampaignListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainDeliverabilityCampaigns;
        }
        
    }
}
