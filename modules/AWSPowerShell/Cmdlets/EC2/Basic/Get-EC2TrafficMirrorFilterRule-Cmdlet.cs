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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describe traffic mirror filters that determine the traffic that is mirrored.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2TrafficMirrorFilterRule")]
    [OutputType("Amazon.EC2.Model.TrafficMirrorFilterRule")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeTrafficMirrorFilterRules API operation.", Operation = new[] {"DescribeTrafficMirrorFilterRules"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeTrafficMirrorFilterRulesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TrafficMirrorFilterRule or Amazon.EC2.Model.DescribeTrafficMirrorFilterRulesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.TrafficMirrorFilterRule objects.",
        "The service call response (type Amazon.EC2.Model.DescribeTrafficMirrorFilterRulesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2TrafficMirrorFilterRuleCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Traffic mirror filters.</para><ul><li><para><c>traffic-mirror-filter-rule-id</c>: The ID of the Traffic Mirror rule.</para></li><li><para><c>traffic-mirror-filter-id</c>: The ID of the filter that this rule is associated
        /// with.</para></li><li><para><c>rule-number</c>: The number of the Traffic Mirror rule.</para></li><li><para><c>rule-action</c>: The action taken on the filtered traffic. Possible actions are
        /// <c>accept</c> and <c>reject</c>.</para></li><li><para><c>traffic-direction</c>: The traffic direction. Possible directions are <c>ingress</c>
        /// and <c>egress</c>.</para></li><li><para><c>protocol</c>: The protocol, for example UDP, assigned to the Traffic Mirror rule.</para></li><li><para><c>source-cidr-block</c>: The source CIDR block assigned to the Traffic Mirror rule.</para></li><li><para><c>destination-cidr-block</c>: The destination CIDR block assigned to the Traffic
        /// Mirror rule.</para></li><li><para><c>description</c>: The description of the Traffic Mirror rule.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter TrafficMirrorFilterId
        /// <summary>
        /// <para>
        /// <para>Traffic filter ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TrafficMirrorFilterId { get; set; }
        #endregion
        
        #region Parameter TrafficMirrorFilterRuleId
        /// <summary>
        /// <para>
        /// <para>Traffic filter rule IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrafficMirrorFilterRuleIds")]
        public System.String[] TrafficMirrorFilterRuleId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para>
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
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrafficMirrorFilterRules'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeTrafficMirrorFilterRulesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeTrafficMirrorFilterRulesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrafficMirrorFilterRules";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrafficMirrorFilterId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrafficMirrorFilterId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrafficMirrorFilterId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeTrafficMirrorFilterRulesResponse, GetEC2TrafficMirrorFilterRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrafficMirrorFilterId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.TrafficMirrorFilterId = this.TrafficMirrorFilterId;
            if (this.TrafficMirrorFilterRuleId != null)
            {
                context.TrafficMirrorFilterRuleId = new List<System.String>(this.TrafficMirrorFilterRuleId);
            }
            
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
            var request = new Amazon.EC2.Model.DescribeTrafficMirrorFilterRulesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.TrafficMirrorFilterId != null)
            {
                request.TrafficMirrorFilterId = cmdletContext.TrafficMirrorFilterId;
            }
            if (cmdletContext.TrafficMirrorFilterRuleId != null)
            {
                request.TrafficMirrorFilterRuleIds = cmdletContext.TrafficMirrorFilterRuleId;
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
        
        private Amazon.EC2.Model.DescribeTrafficMirrorFilterRulesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeTrafficMirrorFilterRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeTrafficMirrorFilterRules");
            try
            {
                #if DESKTOP
                return client.DescribeTrafficMirrorFilterRules(request);
                #elif CORECLR
                return client.DescribeTrafficMirrorFilterRulesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String TrafficMirrorFilterId { get; set; }
            public List<System.String> TrafficMirrorFilterRuleId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeTrafficMirrorFilterRulesResponse, GetEC2TrafficMirrorFilterRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrafficMirrorFilterRules;
        }
        
    }
}
