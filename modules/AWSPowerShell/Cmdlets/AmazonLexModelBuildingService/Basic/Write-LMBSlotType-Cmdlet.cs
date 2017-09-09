/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// fields, Amazon Lex throws an exception.
    /// </para><para>
    /// This operation requires permissions for the <code>lex:PutSlotType</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "LMBSlotType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelBuildingService.Model.PutSlotTypeResponse")]
    [AWSCmdlet("Invokes the PutSlotType operation against Amazon Lex Model Building Service.", Operation = new[] {"PutSlotType"})]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.PutSlotTypeResponse",
        "This cmdlet returns a Amazon.LexModelBuildingService.Model.PutSlotTypeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteLMBSlotTypeCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
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
        [System.Management.Automation.Parameter]
        public System.String Checksum { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the slot type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnumerationValue
        /// <summary>
        /// <para>
        /// <para>A list of <code>EnumerationValue</code> objects that defines the values that the slot
        /// type can take. Each value can have a list of <code>synonyms</code>, which are additional
        /// values that help train the machine learning model about the values that it resolves
        /// for a slot. </para><para>When Amazon Lex resolves a slot value, it generates a resolution list that contains
        /// up to five possible values for the slot. If you are using a Lambda function, this
        /// resolution list is passed to the function. If you are not using a Lambda function
        /// you can choose to return the value that the user entered or the first value in the
        /// resolution list as the slot value. The <code>valueSelectionStrategy</code> field indicates
        /// the option to use. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
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
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.SlotValueSelectionStrategy")]
        public Amazon.LexModelBuildingService.SlotValueSelectionStrategy ValueSelectionStrategy { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LMBSlotType (PutSlotType)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Checksum = this.Checksum;
            context.Description = this.Description;
            if (this.EnumerationValue != null)
            {
                context.EnumerationValues = new List<Amazon.LexModelBuildingService.Model.EnumerationValue>(this.EnumerationValue);
            }
            context.Name = this.Name;
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
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnumerationValues != null)
            {
                request.EnumerationValues = cmdletContext.EnumerationValues;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ValueSelectionStrategy != null)
            {
                request.ValueSelectionStrategy = cmdletContext.ValueSelectionStrategy;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutSlotTypeAsync(request);
                return task.Result;
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
            public System.String Description { get; set; }
            public List<Amazon.LexModelBuildingService.Model.EnumerationValue> EnumerationValues { get; set; }
            public System.String Name { get; set; }
            public Amazon.LexModelBuildingService.SlotValueSelectionStrategy ValueSelectionStrategy { get; set; }
        }
        
    }
}
