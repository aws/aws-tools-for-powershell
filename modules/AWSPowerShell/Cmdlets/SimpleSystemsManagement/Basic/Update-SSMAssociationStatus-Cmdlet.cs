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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Updates the status of the Amazon Web Services Systems Manager document (SSM document)
    /// associated with the specified managed node.
    /// 
    ///  
    /// <para><code>UpdateAssociationStatus</code> is primarily used by the Amazon Web Services
    /// Systems Manager Agent (SSM Agent) to report status updates about your associations
    /// and is only used for associations created with the <code>InstanceId</code> legacy
    /// parameter.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SSMAssociationStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.AssociationDescription")]
    [AWSCmdlet("Calls the AWS Systems Manager UpdateAssociationStatus API operation.", Operation = new[] {"UpdateAssociationStatus"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.AssociationDescription or Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.AssociationDescription object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSSMAssociationStatusCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociationStatus_AdditionalInfo
        /// <summary>
        /// <para>
        /// <para>A user-defined string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssociationStatus_AdditionalInfo { get; set; }
        #endregion
        
        #region Parameter AssociationStatus_Date
        /// <summary>
        /// <para>
        /// <para>The date when the status changed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? AssociationStatus_Date { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The managed node ID.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter AssociationStatus_Message
        /// <summary>
        /// <para>
        /// <para>The reason for the status.</para>
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
        public System.String AssociationStatus_Message { get; set; }
        #endregion
        
        #region Parameter AssociationStatus_Name
        /// <summary>
        /// <para>
        /// <para>The status.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.AssociationStatusName")]
        public Amazon.SimpleSystemsManagement.AssociationStatusName AssociationStatus_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the SSM document.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssociationDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssociationDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMAssociationStatus (UpdateAssociationStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse, UpdateSSMAssociationStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssociationStatus_AdditionalInfo = this.AssociationStatus_AdditionalInfo;
            context.AssociationStatus_Date = this.AssociationStatus_Date;
            #if MODULAR
            if (this.AssociationStatus_Date == null && ParameterWasBound(nameof(this.AssociationStatus_Date)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationStatus_Date which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssociationStatus_Message = this.AssociationStatus_Message;
            #if MODULAR
            if (this.AssociationStatus_Message == null && ParameterWasBound(nameof(this.AssociationStatus_Message)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationStatus_Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssociationStatus_Name = this.AssociationStatus_Name;
            #if MODULAR
            if (this.AssociationStatus_Name == null && ParameterWasBound(nameof(this.AssociationStatus_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationStatus_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusRequest();
            
            
             // populate AssociationStatus
            var requestAssociationStatusIsNull = true;
            request.AssociationStatus = new Amazon.SimpleSystemsManagement.Model.AssociationStatus();
            System.String requestAssociationStatus_associationStatus_AdditionalInfo = null;
            if (cmdletContext.AssociationStatus_AdditionalInfo != null)
            {
                requestAssociationStatus_associationStatus_AdditionalInfo = cmdletContext.AssociationStatus_AdditionalInfo;
            }
            if (requestAssociationStatus_associationStatus_AdditionalInfo != null)
            {
                request.AssociationStatus.AdditionalInfo = requestAssociationStatus_associationStatus_AdditionalInfo;
                requestAssociationStatusIsNull = false;
            }
            System.DateTime? requestAssociationStatus_associationStatus_Date = null;
            if (cmdletContext.AssociationStatus_Date != null)
            {
                requestAssociationStatus_associationStatus_Date = cmdletContext.AssociationStatus_Date.Value;
            }
            if (requestAssociationStatus_associationStatus_Date != null)
            {
                request.AssociationStatus.Date = requestAssociationStatus_associationStatus_Date.Value;
                requestAssociationStatusIsNull = false;
            }
            System.String requestAssociationStatus_associationStatus_Message = null;
            if (cmdletContext.AssociationStatus_Message != null)
            {
                requestAssociationStatus_associationStatus_Message = cmdletContext.AssociationStatus_Message;
            }
            if (requestAssociationStatus_associationStatus_Message != null)
            {
                request.AssociationStatus.Message = requestAssociationStatus_associationStatus_Message;
                requestAssociationStatusIsNull = false;
            }
            Amazon.SimpleSystemsManagement.AssociationStatusName requestAssociationStatus_associationStatus_Name = null;
            if (cmdletContext.AssociationStatus_Name != null)
            {
                requestAssociationStatus_associationStatus_Name = cmdletContext.AssociationStatus_Name;
            }
            if (requestAssociationStatus_associationStatus_Name != null)
            {
                request.AssociationStatus.Name = requestAssociationStatus_associationStatus_Name;
                requestAssociationStatusIsNull = false;
            }
             // determine if request.AssociationStatus should be set to null
            if (requestAssociationStatusIsNull)
            {
                request.AssociationStatus = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "UpdateAssociationStatus");
            try
            {
                #if DESKTOP
                return client.UpdateAssociationStatus(request);
                #elif CORECLR
                return client.UpdateAssociationStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociationStatus_AdditionalInfo { get; set; }
            public System.DateTime? AssociationStatus_Date { get; set; }
            public System.String AssociationStatus_Message { get; set; }
            public Amazon.SimpleSystemsManagement.AssociationStatusName AssociationStatus_Name { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse, UpdateSSMAssociationStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssociationDescription;
        }
        
    }
}
