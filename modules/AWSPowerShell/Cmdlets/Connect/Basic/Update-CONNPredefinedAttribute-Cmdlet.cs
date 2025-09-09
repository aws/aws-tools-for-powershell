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
    /// Updates a predefined attribute for the specified Amazon Connect instance. A <i>predefined
    /// attribute</i> is made up of a name and a value.
    /// 
    ///  
    /// <para>
    /// For the predefined attributes per instance quota, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/amazon-connect-service-limits.html#connect-quotas">Amazon
    /// Connect quotas</a>.
    /// </para><para><b>Use cases</b></para><para>
    /// Following are common uses cases for this API:
    /// </para><ul><li><para>
    /// Update routing proficiency (for example, agent certification) that has predefined
    /// values (for example, a list of possible certifications). For more information, see
    /// <a href="https://docs.aws.amazon.com/connect/latest/adminguide/predefined-attributes.html">Create
    /// predefined attributes for routing contacts to agents</a>.
    /// </para></li><li><para>
    /// Update an attribute for business unit name that has a list of predefined business
    /// unit names used in your organization. This is a use case where information for a contact
    /// varies between transfers or conferences. For more information, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/use-contact-segment-attributes.html">Use
    /// contact segment attributes</a>.
    /// </para></li></ul><para><b>Endpoints</b>: See <a href="https://docs.aws.amazon.com/general/latest/gr/connect_region.html">Amazon
    /// Connect endpoints and quotas</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CONNPredefinedAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdatePredefinedAttribute API operation.", Operation = new[] {"UpdatePredefinedAttribute"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdatePredefinedAttributeResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdatePredefinedAttributeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdatePredefinedAttributeResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNPredefinedAttributeCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeConfiguration_EnableValueValidationOnAssociation
        /// <summary>
        /// <para>
        /// <para>When this parameter is set to true, Amazon Connect enforces strict validation on the
        /// specific values, if the values are predefined in attributes. The contact will store
        /// only valid and predefined values for the predefined attribute key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AttributeConfiguration_EnableValueValidationOnAssociation { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can find the instance ID in the
        /// Amazon Resource Name (ARN) of the instance.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the predefined attribute.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Purpose
        /// <summary>
        /// <para>
        /// <para>Values that enable you to categorize your predefined attributes. You can use them
        /// in custom UI elements across the Amazon Connect admin website.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Purposes")]
        public System.String[] Purpose { get; set; }
        #endregion
        
        #region Parameter Values_StringList
        /// <summary>
        /// <para>
        /// <para>Predefined attribute values of type string list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Values_StringList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdatePredefinedAttributeResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNPredefinedAttribute (UpdatePredefinedAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdatePredefinedAttributeResponse, UpdateCONNPredefinedAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AttributeConfiguration_EnableValueValidationOnAssociation = this.AttributeConfiguration_EnableValueValidationOnAssociation;
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
            if (this.Purpose != null)
            {
                context.Purpose = new List<System.String>(this.Purpose);
            }
            if (this.Values_StringList != null)
            {
                context.Values_StringList = new List<System.String>(this.Values_StringList);
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
            var request = new Amazon.Connect.Model.UpdatePredefinedAttributeRequest();
            
            
             // populate AttributeConfiguration
            var requestAttributeConfigurationIsNull = true;
            request.AttributeConfiguration = new Amazon.Connect.Model.InputPredefinedAttributeConfiguration();
            System.Boolean? requestAttributeConfiguration_attributeConfiguration_EnableValueValidationOnAssociation = null;
            if (cmdletContext.AttributeConfiguration_EnableValueValidationOnAssociation != null)
            {
                requestAttributeConfiguration_attributeConfiguration_EnableValueValidationOnAssociation = cmdletContext.AttributeConfiguration_EnableValueValidationOnAssociation.Value;
            }
            if (requestAttributeConfiguration_attributeConfiguration_EnableValueValidationOnAssociation != null)
            {
                request.AttributeConfiguration.EnableValueValidationOnAssociation = requestAttributeConfiguration_attributeConfiguration_EnableValueValidationOnAssociation.Value;
                requestAttributeConfigurationIsNull = false;
            }
             // determine if request.AttributeConfiguration should be set to null
            if (requestAttributeConfigurationIsNull)
            {
                request.AttributeConfiguration = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Purpose != null)
            {
                request.Purposes = cmdletContext.Purpose;
            }
            
             // populate Values
            var requestValuesIsNull = true;
            request.Values = new Amazon.Connect.Model.PredefinedAttributeValues();
            List<System.String> requestValues_values_StringList = null;
            if (cmdletContext.Values_StringList != null)
            {
                requestValues_values_StringList = cmdletContext.Values_StringList;
            }
            if (requestValues_values_StringList != null)
            {
                request.Values.StringList = requestValues_values_StringList;
                requestValuesIsNull = false;
            }
             // determine if request.Values should be set to null
            if (requestValuesIsNull)
            {
                request.Values = null;
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
        
        private Amazon.Connect.Model.UpdatePredefinedAttributeResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdatePredefinedAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdatePredefinedAttribute");
            try
            {
                #if DESKTOP
                return client.UpdatePredefinedAttribute(request);
                #elif CORECLR
                return client.UpdatePredefinedAttributeAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AttributeConfiguration_EnableValueValidationOnAssociation { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Purpose { get; set; }
            public List<System.String> Values_StringList { get; set; }
            public System.Func<Amazon.Connect.Model.UpdatePredefinedAttributeResponse, UpdateCONNPredefinedAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
