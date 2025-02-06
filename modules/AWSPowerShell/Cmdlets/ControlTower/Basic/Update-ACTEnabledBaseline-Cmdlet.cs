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
using Amazon.ControlTower;
using Amazon.ControlTower.Model;

namespace Amazon.PowerShell.Cmdlets.ACT
{
    /// <summary>
    /// Updates an <c>EnabledBaseline</c> resource's applied parameters or version. For usage
    /// examples, see <a href="https://docs.aws.amazon.com/controltower/latest/userguide/baseline-api-examples.html"><i>the Amazon Web Services Control Tower User Guide</i></a>.
    /// </summary>
    [Cmdlet("Update", "ACTEnabledBaseline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Control Tower UpdateEnabledBaseline API operation.", Operation = new[] {"UpdateEnabledBaseline"}, SelectReturnType = typeof(Amazon.ControlTower.Model.UpdateEnabledBaselineResponse))]
    [AWSCmdletOutput("System.String or Amazon.ControlTower.Model.UpdateEnabledBaselineResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ControlTower.Model.UpdateEnabledBaselineResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateACTEnabledBaselineCmdlet : AmazonControlTowerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BaselineVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the new <c>Baseline</c> version, to which the <c>EnabledBaseline</c> should
        /// be updated.</para>
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
        public System.String BaselineVersion { get; set; }
        #endregion
        
        #region Parameter EnabledBaselineIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the <c>EnabledBaseline</c> resource to be updated.</para>
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
        public System.String EnabledBaselineIdentifier { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>Parameters to apply when making an update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.ControlTower.Model.EnabledBaselineParameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationIdentifier'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.UpdateEnabledBaselineResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.UpdateEnabledBaselineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationIdentifier";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnabledBaselineIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ACTEnabledBaseline (UpdateEnabledBaseline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.UpdateEnabledBaselineResponse, UpdateACTEnabledBaselineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BaselineVersion = this.BaselineVersion;
            #if MODULAR
            if (this.BaselineVersion == null && ParameterWasBound(nameof(this.BaselineVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter BaselineVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnabledBaselineIdentifier = this.EnabledBaselineIdentifier;
            #if MODULAR
            if (this.EnabledBaselineIdentifier == null && ParameterWasBound(nameof(this.EnabledBaselineIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EnabledBaselineIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.ControlTower.Model.EnabledBaselineParameter>(this.Parameter);
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
            // create request
            var request = new Amazon.ControlTower.Model.UpdateEnabledBaselineRequest();
            
            if (cmdletContext.BaselineVersion != null)
            {
                request.BaselineVersion = cmdletContext.BaselineVersion;
            }
            if (cmdletContext.EnabledBaselineIdentifier != null)
            {
                request.EnabledBaselineIdentifier = cmdletContext.EnabledBaselineIdentifier;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
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
        
        private Amazon.ControlTower.Model.UpdateEnabledBaselineResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.UpdateEnabledBaselineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "UpdateEnabledBaseline");
            try
            {
                #if DESKTOP
                return client.UpdateEnabledBaseline(request);
                #elif CORECLR
                return client.UpdateEnabledBaselineAsync(request).GetAwaiter().GetResult();
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
            public System.String BaselineVersion { get; set; }
            public System.String EnabledBaselineIdentifier { get; set; }
            public List<Amazon.ControlTower.Model.EnabledBaselineParameter> Parameter { get; set; }
            public System.Func<Amazon.ControlTower.Model.UpdateEnabledBaselineResponse, UpdateACTEnabledBaselineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationIdentifier;
        }
        
    }
}
