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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Updates the privacy budget template for the specified membership.
    /// </summary>
    [Cmdlet("Update", "CRSPrivacyBudgetTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.PrivacyBudgetTemplate")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service UpdatePrivacyBudgetTemplate API operation.", Operation = new[] {"UpdatePrivacyBudgetTemplate"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.UpdatePrivacyBudgetTemplateResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.PrivacyBudgetTemplate or Amazon.CleanRooms.Model.UpdatePrivacyBudgetTemplateResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.PrivacyBudgetTemplate object.",
        "The service call response (type Amazon.CleanRooms.Model.UpdatePrivacyBudgetTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCRSPrivacyBudgetTemplateCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DifferentialPrivacy_Epsilon
        /// <summary>
        /// <para>
        /// <para>The updated epsilon value that you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_DifferentialPrivacy_Epsilon")]
        public System.Int32? DifferentialPrivacy_Epsilon { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for one of your memberships for a collaboration. The privacy budget
        /// template is updated in the collaboration that this membership belongs to. Accepts
        /// a membership ID.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter PrivacyBudgetTemplateIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for your privacy budget template that you want to update.</para>
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
        public System.String PrivacyBudgetTemplateIdentifier { get; set; }
        #endregion
        
        #region Parameter PrivacyBudgetType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of the privacy budget template.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.PrivacyBudgetType")]
        public Amazon.CleanRooms.PrivacyBudgetType PrivacyBudgetType { get; set; }
        #endregion
        
        #region Parameter DifferentialPrivacy_UsersNoisePerQuery
        /// <summary>
        /// <para>
        /// <para>The updated value of noise added per query. It is measured in terms of the number
        /// of users whose contributions you want to obscure. This value governs the rate at which
        /// the privacy budget is depleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_DifferentialPrivacy_UsersNoisePerQuery")]
        public System.Int32? DifferentialPrivacy_UsersNoisePerQuery { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PrivacyBudgetTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.UpdatePrivacyBudgetTemplateResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.UpdatePrivacyBudgetTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PrivacyBudgetTemplate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PrivacyBudgetTemplateIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PrivacyBudgetTemplateIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PrivacyBudgetTemplateIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PrivacyBudgetTemplateIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CRSPrivacyBudgetTemplate (UpdatePrivacyBudgetTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.UpdatePrivacyBudgetTemplateResponse, UpdateCRSPrivacyBudgetTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PrivacyBudgetTemplateIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DifferentialPrivacy_Epsilon = this.DifferentialPrivacy_Epsilon;
            context.DifferentialPrivacy_UsersNoisePerQuery = this.DifferentialPrivacy_UsersNoisePerQuery;
            context.PrivacyBudgetTemplateIdentifier = this.PrivacyBudgetTemplateIdentifier;
            #if MODULAR
            if (this.PrivacyBudgetTemplateIdentifier == null && ParameterWasBound(nameof(this.PrivacyBudgetTemplateIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter PrivacyBudgetTemplateIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrivacyBudgetType = this.PrivacyBudgetType;
            #if MODULAR
            if (this.PrivacyBudgetType == null && ParameterWasBound(nameof(this.PrivacyBudgetType)))
            {
                WriteWarning("You are passing $null as a value for parameter PrivacyBudgetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.UpdatePrivacyBudgetTemplateRequest();
            
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            
             // populate Parameters
            var requestParametersIsNull = true;
            request.Parameters = new Amazon.CleanRooms.Model.PrivacyBudgetTemplateUpdateParameters();
            Amazon.CleanRooms.Model.DifferentialPrivacyTemplateUpdateParameters requestParameters_parameters_DifferentialPrivacy = null;
            
             // populate DifferentialPrivacy
            var requestParameters_parameters_DifferentialPrivacyIsNull = true;
            requestParameters_parameters_DifferentialPrivacy = new Amazon.CleanRooms.Model.DifferentialPrivacyTemplateUpdateParameters();
            System.Int32? requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_Epsilon = null;
            if (cmdletContext.DifferentialPrivacy_Epsilon != null)
            {
                requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_Epsilon = cmdletContext.DifferentialPrivacy_Epsilon.Value;
            }
            if (requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_Epsilon != null)
            {
                requestParameters_parameters_DifferentialPrivacy.Epsilon = requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_Epsilon.Value;
                requestParameters_parameters_DifferentialPrivacyIsNull = false;
            }
            System.Int32? requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_UsersNoisePerQuery = null;
            if (cmdletContext.DifferentialPrivacy_UsersNoisePerQuery != null)
            {
                requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_UsersNoisePerQuery = cmdletContext.DifferentialPrivacy_UsersNoisePerQuery.Value;
            }
            if (requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_UsersNoisePerQuery != null)
            {
                requestParameters_parameters_DifferentialPrivacy.UsersNoisePerQuery = requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_UsersNoisePerQuery.Value;
                requestParameters_parameters_DifferentialPrivacyIsNull = false;
            }
             // determine if requestParameters_parameters_DifferentialPrivacy should be set to null
            if (requestParameters_parameters_DifferentialPrivacyIsNull)
            {
                requestParameters_parameters_DifferentialPrivacy = null;
            }
            if (requestParameters_parameters_DifferentialPrivacy != null)
            {
                request.Parameters.DifferentialPrivacy = requestParameters_parameters_DifferentialPrivacy;
                requestParametersIsNull = false;
            }
             // determine if request.Parameters should be set to null
            if (requestParametersIsNull)
            {
                request.Parameters = null;
            }
            if (cmdletContext.PrivacyBudgetTemplateIdentifier != null)
            {
                request.PrivacyBudgetTemplateIdentifier = cmdletContext.PrivacyBudgetTemplateIdentifier;
            }
            if (cmdletContext.PrivacyBudgetType != null)
            {
                request.PrivacyBudgetType = cmdletContext.PrivacyBudgetType;
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
        
        private Amazon.CleanRooms.Model.UpdatePrivacyBudgetTemplateResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.UpdatePrivacyBudgetTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "UpdatePrivacyBudgetTemplate");
            try
            {
                #if DESKTOP
                return client.UpdatePrivacyBudgetTemplate(request);
                #elif CORECLR
                return client.UpdatePrivacyBudgetTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String MembershipIdentifier { get; set; }
            public System.Int32? DifferentialPrivacy_Epsilon { get; set; }
            public System.Int32? DifferentialPrivacy_UsersNoisePerQuery { get; set; }
            public System.String PrivacyBudgetTemplateIdentifier { get; set; }
            public Amazon.CleanRooms.PrivacyBudgetType PrivacyBudgetType { get; set; }
            public System.Func<Amazon.CleanRooms.Model.UpdatePrivacyBudgetTemplateResponse, UpdateCRSPrivacyBudgetTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PrivacyBudgetTemplate;
        }
        
    }
}
