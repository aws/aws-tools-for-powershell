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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates any of the metadata for a test case, such as the name, description, and status
    /// or content of an existing test case. This API doesn't allow customers to update the
    /// tags of the test case resource for the specified Amazon Connect instance.
    /// </summary>
    [Cmdlet("Update", "CONNTestCase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateTestCase API operation.", Operation = new[] {"UpdateTestCase"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateTestCaseResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateTestCaseResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateTestCaseResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNTestCaseCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The JSON string that represents the content of the test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the test case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EntryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The destination phone number for the test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber { get; set; }
        #endregion
        
        #region Parameter EntryPoint_VoiceCallEntryPointParameters_FlowId
        /// <summary>
        /// <para>
        /// <para>The flow identifier for the test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntryPoint_VoiceCallEntryPointParameters_FlowId { get; set; }
        #endregion
        
        #region Parameter InitializationData
        /// <summary>
        /// <para>
        /// <para>Defines the test attributes for precise data representation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitializationData { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter LastModifiedRegion
        /// <summary>
        /// <para>
        /// <para>The region in which the resource was last modified</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LastModifiedRegion { get; set; }
        #endregion
        
        #region Parameter LastModifiedTime
        /// <summary>
        /// <para>
        /// <para>The time at which the resource was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? LastModifiedTime { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the test case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EntryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber
        /// <summary>
        /// <para>
        /// <para>The source phone number for the test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Indicates the test status as either SAVED or PUBLISHED. The PUBLISHED status will
        /// initiate validation on the content. The SAVED status does not initiate validation
        /// of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.TestCaseStatus")]
        public Amazon.Connect.TestCaseStatus Status { get; set; }
        #endregion
        
        #region Parameter TestCaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the test case to update.</para>
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
        public System.String TestCaseId { get; set; }
        #endregion
        
        #region Parameter EntryPoint_Type
        /// <summary>
        /// <para>
        /// <para>The type of entry point.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.TestCaseEntryPointType")]
        public Amazon.Connect.TestCaseEntryPointType EntryPoint_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateTestCaseResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TestCaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNTestCase (UpdateTestCase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateTestCaseResponse, UpdateCONNTestCaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Content = this.Content;
            context.Description = this.Description;
            context.EntryPoint_Type = this.EntryPoint_Type;
            context.EntryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber = this.EntryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber;
            context.EntryPoint_VoiceCallEntryPointParameters_FlowId = this.EntryPoint_VoiceCallEntryPointParameters_FlowId;
            context.EntryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber = this.EntryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber;
            context.InitializationData = this.InitializationData;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LastModifiedRegion = this.LastModifiedRegion;
            context.LastModifiedTime = this.LastModifiedTime;
            context.Name = this.Name;
            context.Status = this.Status;
            context.TestCaseId = this.TestCaseId;
            #if MODULAR
            if (this.TestCaseId == null && ParameterWasBound(nameof(this.TestCaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter TestCaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateTestCaseRequest();
            
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EntryPoint
            var requestEntryPointIsNull = true;
            request.EntryPoint = new Amazon.Connect.Model.TestCaseEntryPoint();
            Amazon.Connect.TestCaseEntryPointType requestEntryPoint_entryPoint_Type = null;
            if (cmdletContext.EntryPoint_Type != null)
            {
                requestEntryPoint_entryPoint_Type = cmdletContext.EntryPoint_Type;
            }
            if (requestEntryPoint_entryPoint_Type != null)
            {
                request.EntryPoint.Type = requestEntryPoint_entryPoint_Type;
                requestEntryPointIsNull = false;
            }
            Amazon.Connect.Model.VoiceCallEntryPointParameters requestEntryPoint_entryPoint_VoiceCallEntryPointParameters = null;
            
             // populate VoiceCallEntryPointParameters
            var requestEntryPoint_entryPoint_VoiceCallEntryPointParametersIsNull = true;
            requestEntryPoint_entryPoint_VoiceCallEntryPointParameters = new Amazon.Connect.Model.VoiceCallEntryPointParameters();
            System.String requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber = null;
            if (cmdletContext.EntryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber != null)
            {
                requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber = cmdletContext.EntryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber;
            }
            if (requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber != null)
            {
                requestEntryPoint_entryPoint_VoiceCallEntryPointParameters.DestinationPhoneNumber = requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber;
                requestEntryPoint_entryPoint_VoiceCallEntryPointParametersIsNull = false;
            }
            System.String requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_FlowId = null;
            if (cmdletContext.EntryPoint_VoiceCallEntryPointParameters_FlowId != null)
            {
                requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_FlowId = cmdletContext.EntryPoint_VoiceCallEntryPointParameters_FlowId;
            }
            if (requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_FlowId != null)
            {
                requestEntryPoint_entryPoint_VoiceCallEntryPointParameters.FlowId = requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_FlowId;
                requestEntryPoint_entryPoint_VoiceCallEntryPointParametersIsNull = false;
            }
            System.String requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber = null;
            if (cmdletContext.EntryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber != null)
            {
                requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber = cmdletContext.EntryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber;
            }
            if (requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber != null)
            {
                requestEntryPoint_entryPoint_VoiceCallEntryPointParameters.SourcePhoneNumber = requestEntryPoint_entryPoint_VoiceCallEntryPointParameters_entryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber;
                requestEntryPoint_entryPoint_VoiceCallEntryPointParametersIsNull = false;
            }
             // determine if requestEntryPoint_entryPoint_VoiceCallEntryPointParameters should be set to null
            if (requestEntryPoint_entryPoint_VoiceCallEntryPointParametersIsNull)
            {
                requestEntryPoint_entryPoint_VoiceCallEntryPointParameters = null;
            }
            if (requestEntryPoint_entryPoint_VoiceCallEntryPointParameters != null)
            {
                request.EntryPoint.VoiceCallEntryPointParameters = requestEntryPoint_entryPoint_VoiceCallEntryPointParameters;
                requestEntryPointIsNull = false;
            }
             // determine if request.EntryPoint should be set to null
            if (requestEntryPointIsNull)
            {
                request.EntryPoint = null;
            }
            if (cmdletContext.InitializationData != null)
            {
                request.InitializationData = cmdletContext.InitializationData;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.LastModifiedRegion != null)
            {
                request.LastModifiedRegion = cmdletContext.LastModifiedRegion;
            }
            if (cmdletContext.LastModifiedTime != null)
            {
                request.LastModifiedTime = cmdletContext.LastModifiedTime.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TestCaseId != null)
            {
                request.TestCaseId = cmdletContext.TestCaseId;
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
        
        private Amazon.Connect.Model.UpdateTestCaseResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateTestCaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateTestCase");
            try
            {
                #if DESKTOP
                return client.UpdateTestCase(request);
                #elif CORECLR
                return client.UpdateTestCaseAsync(request).GetAwaiter().GetResult();
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
            public System.String Content { get; set; }
            public System.String Description { get; set; }
            public Amazon.Connect.TestCaseEntryPointType EntryPoint_Type { get; set; }
            public System.String EntryPoint_VoiceCallEntryPointParameters_DestinationPhoneNumber { get; set; }
            public System.String EntryPoint_VoiceCallEntryPointParameters_FlowId { get; set; }
            public System.String EntryPoint_VoiceCallEntryPointParameters_SourcePhoneNumber { get; set; }
            public System.String InitializationData { get; set; }
            public System.String InstanceId { get; set; }
            public System.String LastModifiedRegion { get; set; }
            public System.DateTime? LastModifiedTime { get; set; }
            public System.String Name { get; set; }
            public Amazon.Connect.TestCaseStatus Status { get; set; }
            public System.String TestCaseId { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateTestCaseResponse, UpdateCONNTestCaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
