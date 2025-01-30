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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Creates an override for a rotation in an on-call schedule.
    /// </summary>
    [Cmdlet("New", "SMCRotationOverride", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager Contacts CreateRotationOverride API operation.", Operation = new[] {"CreateRotationOverride"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.CreateRotationOverrideResponse))]
    [AWSCmdletOutput("System.String or Amazon.SSMContacts.Model.CreateRotationOverrideResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SSMContacts.Model.CreateRotationOverrideResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMCRotationOverrideCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The date and time when the override ends.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures that the operation is called only once with the specified details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter NewContactId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the contacts to replace those in the current on-call
        /// rotation with.</para><para>If you want to include any current team members in the override shift, you must include
        /// their ARNs in the new contact ID list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NewContactIds")]
        public System.String[] NewContactId { get; set; }
        #endregion
        
        #region Parameter RotationId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the rotation to create an override for.</para>
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
        public System.String RotationId { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time when the override goes into effect.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RotationOverrideId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.CreateRotationOverrideResponse).
        /// Specifying the name of a property of type Amazon.SSMContacts.Model.CreateRotationOverrideResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RotationOverrideId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RotationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMCRotationOverride (CreateRotationOverride)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.CreateRotationOverrideResponse, NewSMCRotationOverrideCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            if (this.NewContactId != null)
            {
                context.NewContactId = new List<System.String>(this.NewContactId);
            }
            #if MODULAR
            if (this.NewContactId == null && ParameterWasBound(nameof(this.NewContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter NewContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RotationId = this.RotationId;
            #if MODULAR
            if (this.RotationId == null && ParameterWasBound(nameof(this.RotationId)))
            {
                WriteWarning("You are passing $null as a value for parameter RotationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSMContacts.Model.CreateRotationOverrideRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.NewContactId != null)
            {
                request.NewContactIds = cmdletContext.NewContactId;
            }
            if (cmdletContext.RotationId != null)
            {
                request.RotationId = cmdletContext.RotationId;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.SSMContacts.Model.CreateRotationOverrideResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.CreateRotationOverrideRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager Contacts", "CreateRotationOverride");
            try
            {
                #if DESKTOP
                return client.CreateRotationOverride(request);
                #elif CORECLR
                return client.CreateRotationOverrideAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String IdempotencyToken { get; set; }
            public List<System.String> NewContactId { get; set; }
            public System.String RotationId { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.SSMContacts.Model.CreateRotationOverrideResponse, NewSMCRotationOverrideCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RotationOverrideId;
        }
        
    }
}
