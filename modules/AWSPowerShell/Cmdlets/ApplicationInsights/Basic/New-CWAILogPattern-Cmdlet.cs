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
using Amazon.ApplicationInsights;
using Amazon.ApplicationInsights.Model;

namespace Amazon.PowerShell.Cmdlets.CWAI
{
    /// <summary>
    /// Adds an log pattern to a <code>LogPatternSet</code>.
    /// </summary>
    [Cmdlet("New", "CWAILogPattern", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationInsights.Model.LogPattern")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Insights CreateLogPattern API operation.", Operation = new[] {"CreateLogPattern"}, SelectReturnType = typeof(Amazon.ApplicationInsights.Model.CreateLogPatternResponse))]
    [AWSCmdletOutput("Amazon.ApplicationInsights.Model.LogPattern or Amazon.ApplicationInsights.Model.CreateLogPatternResponse",
        "This cmdlet returns an Amazon.ApplicationInsights.Model.LogPattern object.",
        "The service call response (type Amazon.ApplicationInsights.Model.CreateLogPatternResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCWAILogPatternCmdlet : AmazonApplicationInsightsClientCmdlet, IExecutor
    {
        
        #region Parameter Pattern
        /// <summary>
        /// <para>
        /// <para>The log pattern. The pattern must be DFA compatible. Patterns that utilize forward
        /// lookahead or backreference constructions are not supported.</para>
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
        public System.String Pattern { get; set; }
        #endregion
        
        #region Parameter PatternName
        /// <summary>
        /// <para>
        /// <para>The name of the log pattern.</para>
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
        public System.String PatternName { get; set; }
        #endregion
        
        #region Parameter PatternSetName
        /// <summary>
        /// <para>
        /// <para>The name of the log pattern set.</para>
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
        public System.String PatternSetName { get; set; }
        #endregion
        
        #region Parameter Rank
        /// <summary>
        /// <para>
        /// <para>Rank of the log pattern. Must be a value between <code>1</code> and <code>1,000,000</code>.
        /// The patterns are sorted by rank, so we recommend that you set your highest priority
        /// patterns with the lowest rank. A pattern of rank <code>1</code> will be the first
        /// to get matched to a log line. A pattern of rank <code>1,000,000</code> will be last
        /// to get matched. When you configure custom log patterns from the console, a <code>Low</code>
        /// severity pattern translates to a <code>750,000</code> rank. A <code>Medium</code>
        /// severity pattern translates to a <code>500,000</code> rank. And a <code>High</code>
        /// severity pattern translates to a <code>250,000</code> rank. Rank values less than
        /// <code>1</code> or greater than <code>1,000,000</code> are reserved for AWS-provided
        /// patterns. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Rank { get; set; }
        #endregion
        
        #region Parameter ResourceGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the resource group.</para>
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
        public System.String ResourceGroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LogPattern'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationInsights.Model.CreateLogPatternResponse).
        /// Specifying the name of a property of type Amazon.ApplicationInsights.Model.CreateLogPatternResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LogPattern";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PatternName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PatternName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PatternName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PatternName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWAILogPattern (CreateLogPattern)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationInsights.Model.CreateLogPatternResponse, NewCWAILogPatternCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PatternName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Pattern = this.Pattern;
            #if MODULAR
            if (this.Pattern == null && ParameterWasBound(nameof(this.Pattern)))
            {
                WriteWarning("You are passing $null as a value for parameter Pattern which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PatternName = this.PatternName;
            #if MODULAR
            if (this.PatternName == null && ParameterWasBound(nameof(this.PatternName)))
            {
                WriteWarning("You are passing $null as a value for parameter PatternName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PatternSetName = this.PatternSetName;
            #if MODULAR
            if (this.PatternSetName == null && ParameterWasBound(nameof(this.PatternSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter PatternSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Rank = this.Rank;
            #if MODULAR
            if (this.Rank == null && ParameterWasBound(nameof(this.Rank)))
            {
                WriteWarning("You are passing $null as a value for parameter Rank which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceGroupName = this.ResourceGroupName;
            #if MODULAR
            if (this.ResourceGroupName == null && ParameterWasBound(nameof(this.ResourceGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ApplicationInsights.Model.CreateLogPatternRequest();
            
            if (cmdletContext.Pattern != null)
            {
                request.Pattern = cmdletContext.Pattern;
            }
            if (cmdletContext.PatternName != null)
            {
                request.PatternName = cmdletContext.PatternName;
            }
            if (cmdletContext.PatternSetName != null)
            {
                request.PatternSetName = cmdletContext.PatternSetName;
            }
            if (cmdletContext.Rank != null)
            {
                request.Rank = cmdletContext.Rank.Value;
            }
            if (cmdletContext.ResourceGroupName != null)
            {
                request.ResourceGroupName = cmdletContext.ResourceGroupName;
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
        
        private Amazon.ApplicationInsights.Model.CreateLogPatternResponse CallAWSServiceOperation(IAmazonApplicationInsights client, Amazon.ApplicationInsights.Model.CreateLogPatternRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Insights", "CreateLogPattern");
            try
            {
                #if DESKTOP
                return client.CreateLogPattern(request);
                #elif CORECLR
                return client.CreateLogPatternAsync(request).GetAwaiter().GetResult();
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
            public System.String Pattern { get; set; }
            public System.String PatternName { get; set; }
            public System.String PatternSetName { get; set; }
            public System.Int32? Rank { get; set; }
            public System.String ResourceGroupName { get; set; }
            public System.Func<Amazon.ApplicationInsights.Model.CreateLogPatternResponse, NewCWAILogPatternCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LogPattern;
        }
        
    }
}
