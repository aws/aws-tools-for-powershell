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
using Amazon.DocDBElastic;
using Amazon.DocDBElastic.Model;

namespace Amazon.PowerShell.Cmdlets.DOCE
{
    /// <summary>
    /// The type of pending maintenance action to be applied to the resource.
    /// </summary>
    [Cmdlet("Set", "DOCEPendingMaintenanceAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDBElastic.Model.ResourcePendingMaintenanceAction")]
    [AWSCmdlet("Calls the Amazon DocumentDB Elastic Clusters ApplyPendingMaintenanceAction API operation.", Operation = new[] {"ApplyPendingMaintenanceAction"}, SelectReturnType = typeof(Amazon.DocDBElastic.Model.ApplyPendingMaintenanceActionResponse))]
    [AWSCmdletOutput("Amazon.DocDBElastic.Model.ResourcePendingMaintenanceAction or Amazon.DocDBElastic.Model.ApplyPendingMaintenanceActionResponse",
        "This cmdlet returns an Amazon.DocDBElastic.Model.ResourcePendingMaintenanceAction object.",
        "The service call response (type Amazon.DocDBElastic.Model.ApplyPendingMaintenanceActionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetDOCEPendingMaintenanceActionCmdlet : AmazonDocDBElasticClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyAction
        /// <summary>
        /// <para>
        /// <para>The pending maintenance action to apply to the resource.</para><para>Valid actions are:</para><ul><li><para><c>ENGINE_UPDATE<i /></c></para></li><li><para><c>ENGINE_UPGRADE</c></para></li><li><para><c>SECURITY_UPDATE</c></para></li><li><para><c>OS_UPDATE</c></para></li><li><para><c>MASTER_USER_PASSWORD_UPDATE</c></para></li></ul>
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
        public System.String ApplyAction { get; set; }
        #endregion
        
        #region Parameter ApplyOn
        /// <summary>
        /// <para>
        /// <para>A specific date to apply the pending maintenance action. Required if opt-in-type is
        /// <c>APPLY_ON</c>. Format: <c>yyyy/MM/dd HH:mm-yyyy/MM/dd HH:mm</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplyOn { get; set; }
        #endregion
        
        #region Parameter OptInType
        /// <summary>
        /// <para>
        /// <para>A value that specifies the type of opt-in request, or undoes an opt-in request. An
        /// opt-in request of type <c>IMMEDIATE</c> can't be undone.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DocDBElastic.OptInType")]
        public Amazon.DocDBElastic.OptInType OptInType { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon DocumentDB Amazon Resource Name (ARN) of the resource to which the pending
        /// maintenance action applies.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourcePendingMaintenanceAction'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDBElastic.Model.ApplyPendingMaintenanceActionResponse).
        /// Specifying the name of a property of type Amazon.DocDBElastic.Model.ApplyPendingMaintenanceActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourcePendingMaintenanceAction";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-DOCEPendingMaintenanceAction (ApplyPendingMaintenanceAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDBElastic.Model.ApplyPendingMaintenanceActionResponse, SetDOCEPendingMaintenanceActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplyAction = this.ApplyAction;
            #if MODULAR
            if (this.ApplyAction == null && ParameterWasBound(nameof(this.ApplyAction)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplyAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApplyOn = this.ApplyOn;
            context.OptInType = this.OptInType;
            #if MODULAR
            if (this.OptInType == null && ParameterWasBound(nameof(this.OptInType)))
            {
                WriteWarning("You are passing $null as a value for parameter OptInType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DocDBElastic.Model.ApplyPendingMaintenanceActionRequest();
            
            if (cmdletContext.ApplyAction != null)
            {
                request.ApplyAction = cmdletContext.ApplyAction;
            }
            if (cmdletContext.ApplyOn != null)
            {
                request.ApplyOn = cmdletContext.ApplyOn;
            }
            if (cmdletContext.OptInType != null)
            {
                request.OptInType = cmdletContext.OptInType;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.DocDBElastic.Model.ApplyPendingMaintenanceActionResponse CallAWSServiceOperation(IAmazonDocDBElastic client, Amazon.DocDBElastic.Model.ApplyPendingMaintenanceActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB Elastic Clusters", "ApplyPendingMaintenanceAction");
            try
            {
                #if DESKTOP
                return client.ApplyPendingMaintenanceAction(request);
                #elif CORECLR
                return client.ApplyPendingMaintenanceActionAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplyAction { get; set; }
            public System.String ApplyOn { get; set; }
            public Amazon.DocDBElastic.OptInType OptInType { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.DocDBElastic.Model.ApplyPendingMaintenanceActionResponse, SetDOCEPendingMaintenanceActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourcePendingMaintenanceAction;
        }
        
    }
}
