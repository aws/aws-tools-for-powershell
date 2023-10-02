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
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;

namespace Amazon.PowerShell.Cmdlets.LMB
{
    /// <summary>
    /// Creates a custom slot type or replaces an existing custom slot type.
    /// 
    ///  
    /// <para>
    /// To create a custom slot type, specify a name for the slot type and a set of enumeration
    /// values, which are the values that a slot of this type can assume. For more information,
    /// see <a>how-it-works</a>.
    /// </para><para>
    /// If you specify the name of an existing slot type, the fields in the request replace
    /// the existing values in the <code>$LATEST</code> version of the slot type. Amazon Lex
    /// removes the fields that you don't provide in the request. If you don't specify required
    /// fields, Amazon Lex throws an exception. When you update the <code>$LATEST</code> version
    /// of a slot type, if a bot uses the <code>$LATEST</code> version of an intent that contains
    /// the slot type, the bot's <code>status</code> field is set to <code>NOT_BUILT</code>.
    /// </para><para>
    /// This operation requires permissions for the <code>lex:PutSlotType</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "LMBSlotType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelBuildingService.Model.PutSlotTypeResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building Service PutSlotType API operation.", Operation = new[] {"PutSlotType"}, SelectReturnType = typeof(Amazon.LexModelBuildingService.Model.PutSlotTypeResponse))]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.PutSlotTypeResponse",
        "This cmdlet returns an Amazon.LexModelBuildingService.Model.PutSlotTypeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteLMBSlotTypeCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Checksum
        /// <summary>
        /// <para>
        /// <para>Identifies a specific revision of the <code>$LATEST</code> version.</para><para>When you create a new slot type, leave the <code>checksum</code> field blank. If you
        /// specify a checksum you get a <code>BadRequestException</code> exception.</para><para>When you want to update a slot type, set the <code>checksum</code> field to the checksum
        /// of the most recent revision of the <code>$LATEST</code> version. If you don't specify
        /// the <code> checksum</code> field, or if the checksum does not match the <code>$LATEST</code>
        /// version, you get a <code>PreconditionFailedException</code> exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Checksum { get; set; }
        #endregion
        
        #region Parameter CreateVersion
        /// <summary>
        /// <para>
        /// <para>When set to <code>true</code> a new numbered version of the slot type is created.
        /// This is the same as calling the <code>CreateSlotTypeVersion</code> operation. If you
        /// do not specify <code>createVersion</code>, the default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CreateVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the slot type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnumerationValue
        /// <summary>
        /// <para>
        /// <para>A list of <code>EnumerationValue</code> objects that defines the values that the slot
        /// type can take. Each value can have a list of <code>synonyms</code>, which are additional
        /// values that help train the machine learning model about the values that it resolves
        /// for a slot. </para><para>A regular expression slot type doesn't require enumeration values. All other slot
        /// types require a list of enumeration values.</para><para>When Amazon Lex resolves a slot value, it generates a resolution list that contains
        /// up to five possible values for the slot. If you are using a Lambda function, this
        /// resolution list is passed to the function. If you are not using a Lambda function
        /// you can choose to return the value that the user entered or the first value in the
        /// resolution list as the slot value. The <code>valueSelectionStrategy</code> field indicates
        /// the option to use. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnumerationValues")]
        public Amazon.LexModelBuildingService.Model.EnumerationValue[] EnumerationValue { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the slot type. The name is <i>not</i> case sensitive. </para><para>The name can't match a built-in slot type name, or a built-in slot type name with
        /// "AMAZON." removed. For example, because there is a built-in slot type called <code>AMAZON.DATE</code>,
        /// you can't create a custom slot type called <code>DATE</code>.</para><para>For a list of built-in slot types, see <a href="https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/built-in-intent-ref/slot-type-reference">Slot
        /// Type Reference</a> in the <i>Alexa Skills Kit</i>.</para>
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
        
        #region Parameter ParentSlotTypeSignature
        /// <summary>
        /// <para>
        /// <para>The built-in slot type used as the parent of the slot type. When you define a parent
        /// slot type, the new slot type has all of the same configuration as the parent.</para><para>Only <code>AMAZON.AlphaNumeric</code> is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentSlotTypeSignature { get; set; }
        #endregion
        
        #region Parameter SlotTypeConfiguration
        /// <summary>
        /// <para>
        /// <para>Configuration information that extends the parent built-in slot type. The configuration
        /// is added to the settings for the parent slot type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlotTypeConfigurations")]
        public Amazon.LexModelBuildingService.Model.SlotTypeConfiguration[] SlotTypeConfiguration { get; set; }
        #endregion
        
        #region Parameter ValueSelectionStrategy
        /// <summary>
        /// <para>
        /// <para>Determines the slot resolution strategy that Amazon Lex uses to return slot type values.
        /// The field can be set to one of the following values:</para><ul><li><para><code>ORIGINAL_VALUE</code> - Returns the value entered by the user, if the user
        /// value is similar to the slot value.</para></li><li><para><code>TOP_RESOLUTION</code> - If there is a resolution list for the slot, return
        /// the first value in the resolution list as the slot type value. If there is no resolution
        /// list, null is returned.</para></li></ul><para>If you don't specify the <code>valueSelectionStrategy</code>, the default is <code>ORIGINAL_VALUE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.SlotValueSelectionStrategy")]
        public Amazon.LexModelBuildingService.SlotValueSelectionStrategy ValueSelectionStrategy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelBuildingService.Model.PutSlotTypeResponse).
        /// Specifying the name of a property of type Amazon.LexModelBuildingService.Model.PutSlotTypeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LMBSlotType (PutSlotType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelBuildingService.Model.PutSlotTypeResponse, WriteLMBSlotTypeCmdlet>(Select) ??
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
            context.Checksum = this.Checksum;
            context.CreateVersion = this.CreateVersion;
            context.Description = this.Description;
            if (this.EnumerationValue != null)
            {
                context.EnumerationValue = new List<Amazon.LexModelBuildingService.Model.EnumerationValue>(this.EnumerationValue);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParentSlotTypeSignature = this.ParentSlotTypeSignature;
            if (this.SlotTypeConfiguration != null)
            {
                context.SlotTypeConfiguration = new List<Amazon.LexModelBuildingService.Model.SlotTypeConfiguration>(this.SlotTypeConfiguration);
            }
            context.ValueSelectionStrategy = this.ValueSelectionStrategy;
            
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
            var request = new Amazon.LexModelBuildingService.Model.PutSlotTypeRequest();
            
            if (cmdletContext.Checksum != null)
            {
                request.Checksum = cmdletContext.Checksum;
            }
            if (cmdletContext.CreateVersion != null)
            {
                request.CreateVersion = cmdletContext.CreateVersion.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnumerationValue != null)
            {
                request.EnumerationValues = cmdletContext.EnumerationValue;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ParentSlotTypeSignature != null)
            {
                request.ParentSlotTypeSignature = cmdletContext.ParentSlotTypeSignature;
            }
            if (cmdletContext.SlotTypeConfiguration != null)
            {
                request.SlotTypeConfigurations = cmdletContext.SlotTypeConfiguration;
            }
            if (cmdletContext.ValueSelectionStrategy != null)
            {
                request.ValueSelectionStrategy = cmdletContext.ValueSelectionStrategy;
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
        
        private Amazon.LexModelBuildingService.Model.PutSlotTypeResponse CallAWSServiceOperation(IAmazonLexModelBuildingService client, Amazon.LexModelBuildingService.Model.PutSlotTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building Service", "PutSlotType");
            try
            {
                #if DESKTOP
                return client.PutSlotType(request);
                #elif CORECLR
                return client.PutSlotTypeAsync(request).GetAwaiter().GetResult();
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
            public System.String Checksum { get; set; }
            public System.Boolean? CreateVersion { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.LexModelBuildingService.Model.EnumerationValue> EnumerationValue { get; set; }
            public System.String Name { get; set; }
            public System.String ParentSlotTypeSignature { get; set; }
            public List<Amazon.LexModelBuildingService.Model.SlotTypeConfiguration> SlotTypeConfiguration { get; set; }
            public Amazon.LexModelBuildingService.SlotValueSelectionStrategy ValueSelectionStrategy { get; set; }
            public System.Func<Amazon.LexModelBuildingService.Model.PutSlotTypeResponse, WriteLMBSlotTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
