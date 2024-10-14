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
using Amazon.Detective;
using Amazon.Detective.Model;

namespace Amazon.PowerShell.Cmdlets.DTCT
{
    /// <summary>
    /// Detective investigations lets you investigate IAM users and IAM roles using indicators
    /// of compromise. An indicator of compromise (IOC) is an artifact observed in or on a
    /// network, system, or environment that can (with a high level of confidence) identify
    /// malicious activity or a security incident. <c>StartInvestigation</c> initiates an
    /// investigation on an entity in a behavior graph.
    /// </summary>
    [Cmdlet("Start", "DTCTInvestigation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Detective StartInvestigation API operation.", Operation = new[] {"StartInvestigation"}, SelectReturnType = typeof(Amazon.Detective.Model.StartInvestigationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Detective.Model.StartInvestigationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Detective.Model.StartInvestigationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartDTCTInvestigationCmdlet : AmazonDetectiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EntityArn
        /// <summary>
        /// <para>
        /// <para>The unique Amazon Resource Name (ARN) of the IAM user and IAM role.</para>
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
        public System.String EntityArn { get; set; }
        #endregion
        
        #region Parameter GraphArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the behavior graph.</para>
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
        public System.String GraphArn { get; set; }
        #endregion
        
        #region Parameter ScopeEndTime
        /// <summary>
        /// <para>
        /// <para>The data and time when the investigation ended. The value is an UTC ISO8601 formatted
        /// string. For example, <c>2021-08-18T16:35:56.284Z</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ScopeEndTime { get; set; }
        #endregion
        
        #region Parameter ScopeStartTime
        /// <summary>
        /// <para>
        /// <para>The data and time when the investigation began. The value is an UTC ISO8601 formatted
        /// string. For example, <c>2021-08-18T16:35:56.284Z</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ScopeStartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvestigationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Detective.Model.StartInvestigationResponse).
        /// Specifying the name of a property of type Amazon.Detective.Model.StartInvestigationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvestigationId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EntityArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EntityArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EntityArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DTCTInvestigation (StartInvestigation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Detective.Model.StartInvestigationResponse, StartDTCTInvestigationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EntityArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EntityArn = this.EntityArn;
            #if MODULAR
            if (this.EntityArn == null && ParameterWasBound(nameof(this.EntityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GraphArn = this.GraphArn;
            #if MODULAR
            if (this.GraphArn == null && ParameterWasBound(nameof(this.GraphArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GraphArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScopeEndTime = this.ScopeEndTime;
            #if MODULAR
            if (this.ScopeEndTime == null && ParameterWasBound(nameof(this.ScopeEndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter ScopeEndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScopeStartTime = this.ScopeStartTime;
            #if MODULAR
            if (this.ScopeStartTime == null && ParameterWasBound(nameof(this.ScopeStartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter ScopeStartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Detective.Model.StartInvestigationRequest();
            
            if (cmdletContext.EntityArn != null)
            {
                request.EntityArn = cmdletContext.EntityArn;
            }
            if (cmdletContext.GraphArn != null)
            {
                request.GraphArn = cmdletContext.GraphArn;
            }
            if (cmdletContext.ScopeEndTime != null)
            {
                request.ScopeEndTime = cmdletContext.ScopeEndTime.Value;
            }
            if (cmdletContext.ScopeStartTime != null)
            {
                request.ScopeStartTime = cmdletContext.ScopeStartTime.Value;
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
        
        private Amazon.Detective.Model.StartInvestigationResponse CallAWSServiceOperation(IAmazonDetective client, Amazon.Detective.Model.StartInvestigationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Detective", "StartInvestigation");
            try
            {
                #if DESKTOP
                return client.StartInvestigation(request);
                #elif CORECLR
                return client.StartInvestigationAsync(request).GetAwaiter().GetResult();
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
            public System.String EntityArn { get; set; }
            public System.String GraphArn { get; set; }
            public System.DateTime? ScopeEndTime { get; set; }
            public System.DateTime? ScopeStartTime { get; set; }
            public System.Func<Amazon.Detective.Model.StartInvestigationResponse, StartDTCTInvestigationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvestigationId;
        }
        
    }
}
