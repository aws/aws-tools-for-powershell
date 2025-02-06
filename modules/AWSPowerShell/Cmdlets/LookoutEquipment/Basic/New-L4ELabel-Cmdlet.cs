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
using Amazon.LookoutEquipment;
using Amazon.LookoutEquipment.Model;

namespace Amazon.PowerShell.Cmdlets.L4E
{
    /// <summary>
    /// Creates a label for an event.
    /// </summary>
    [Cmdlet("New", "L4ELabel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Lookout for Equipment CreateLabel API operation.", Operation = new[] {"CreateLabel"}, SelectReturnType = typeof(Amazon.LookoutEquipment.Model.CreateLabelResponse))]
    [AWSCmdletOutput("System.String or Amazon.LookoutEquipment.Model.CreateLabelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LookoutEquipment.Model.CreateLabelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewL4ELabelCmdlet : AmazonLookoutEquipmentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para> The end time of the labeled event. </para>
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
        
        #region Parameter Equipment
        /// <summary>
        /// <para>
        /// <para> Indicates that a label pertains to a particular piece of equipment. </para><para>Data in this field will be retained for service usage. Follow best practices for the
        /// security of your data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Equipment { get; set; }
        #endregion
        
        #region Parameter FaultCode
        /// <summary>
        /// <para>
        /// <para> Provides additional information about the label. The fault code must be defined in
        /// the FaultCodes attribute of the label group.</para><para>Data in this field will be retained for service usage. Follow best practices for the
        /// security of your data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FaultCode { get; set; }
        #endregion
        
        #region Parameter LabelGroupName
        /// <summary>
        /// <para>
        /// <para> The name of a group of labels. </para><para>Data in this field will be retained for service usage. Follow best practices for the
        /// security of your data. </para>
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
        public System.String LabelGroupName { get; set; }
        #endregion
        
        #region Parameter Note
        /// <summary>
        /// <para>
        /// <para> Metadata providing additional information about the label. </para><para>Data in this field will be retained for service usage. Follow best practices for the
        /// security of your data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Notes")]
        public System.String Note { get; set; }
        #endregion
        
        #region Parameter Rating
        /// <summary>
        /// <para>
        /// <para> Indicates whether a labeled event represents an anomaly. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LookoutEquipment.LabelRating")]
        public Amazon.LookoutEquipment.LabelRating Rating { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para> The start time of the labeled event. </para>
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier for the request to create a label. If you do not set the client
        /// request token, Lookout for Equipment generates one. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LabelId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutEquipment.Model.CreateLabelResponse).
        /// Specifying the name of a property of type Amazon.LookoutEquipment.Model.CreateLabelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LabelId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LabelGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-L4ELabel (CreateLabel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutEquipment.Model.CreateLabelResponse, NewL4ELabelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Equipment = this.Equipment;
            context.FaultCode = this.FaultCode;
            context.LabelGroupName = this.LabelGroupName;
            #if MODULAR
            if (this.LabelGroupName == null && ParameterWasBound(nameof(this.LabelGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter LabelGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Note = this.Note;
            context.Rating = this.Rating;
            #if MODULAR
            if (this.Rating == null && ParameterWasBound(nameof(this.Rating)))
            {
                WriteWarning("You are passing $null as a value for parameter Rating which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LookoutEquipment.Model.CreateLabelRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Equipment != null)
            {
                request.Equipment = cmdletContext.Equipment;
            }
            if (cmdletContext.FaultCode != null)
            {
                request.FaultCode = cmdletContext.FaultCode;
            }
            if (cmdletContext.LabelGroupName != null)
            {
                request.LabelGroupName = cmdletContext.LabelGroupName;
            }
            if (cmdletContext.Note != null)
            {
                request.Notes = cmdletContext.Note;
            }
            if (cmdletContext.Rating != null)
            {
                request.Rating = cmdletContext.Rating;
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
        
        private Amazon.LookoutEquipment.Model.CreateLabelResponse CallAWSServiceOperation(IAmazonLookoutEquipment client, Amazon.LookoutEquipment.Model.CreateLabelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Equipment", "CreateLabel");
            try
            {
                #if DESKTOP
                return client.CreateLabel(request);
                #elif CORECLR
                return client.CreateLabelAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.String Equipment { get; set; }
            public System.String FaultCode { get; set; }
            public System.String LabelGroupName { get; set; }
            public System.String Note { get; set; }
            public Amazon.LookoutEquipment.LabelRating Rating { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.LookoutEquipment.Model.CreateLabelResponse, NewL4ELabelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LabelId;
        }
        
    }
}
