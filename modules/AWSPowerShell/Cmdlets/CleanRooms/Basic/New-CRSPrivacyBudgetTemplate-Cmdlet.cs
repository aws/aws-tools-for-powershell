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
using System.Threading;
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a privacy budget template for a specified membership. Each membership can
    /// have only one privacy budget template, but it can be deleted and recreated. If you
    /// need to change the privacy budget template for a membership, use the <a>UpdatePrivacyBudgetTemplate</a>
    /// operation.
    /// </summary>
    [Cmdlet("New", "CRSPrivacyBudgetTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.PrivacyBudgetTemplate")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreatePrivacyBudgetTemplate API operation.", Operation = new[] {"CreatePrivacyBudgetTemplate"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreatePrivacyBudgetTemplateResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.PrivacyBudgetTemplate or Amazon.CleanRooms.Model.CreatePrivacyBudgetTemplateResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.PrivacyBudgetTemplate object.",
        "The service call response (type Amazon.CleanRooms.Model.CreatePrivacyBudgetTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRSPrivacyBudgetTemplateCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoRefresh
        /// <summary>
        /// <para>
        /// <para>How often the privacy budget refreshes.</para><important><para>If you plan to regularly bring new data into the collaboration, you can use <c>CALENDAR_MONTH</c>
        /// to automatically get a new privacy budget for the collaboration every calendar month.
        /// Choosing this option allows arbitrary amounts of information to be revealed about
        /// rows of the data when repeatedly queries across refreshes. Avoid choosing this if
        /// the same rows will be repeatedly queried between privacy budget refreshes.</para></important>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.PrivacyBudgetTemplateAutoRefresh")]
        public Amazon.CleanRooms.PrivacyBudgetTemplateAutoRefresh AutoRefresh { get; set; }
        #endregion
        
        #region Parameter DifferentialPrivacy_Epsilon
        /// <summary>
        /// <para>
        /// <para>The epsilon value that you want to use.</para>
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
        /// template is created in the collaboration that this membership belongs to. Accepts
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional label that you can assign to a resource when you create it. Each tag consists
        /// of a key and an optional value, both of which you define. When you use tagging, you
        /// can also use tag-based access control in IAM policies to control access to this resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter DifferentialPrivacy_UsersNoisePerQuery
        /// <summary>
        /// <para>
        /// <para>Noise added per query is measured in terms of the number of users whose contributions
        /// you want to obscure. This value governs the rate at which the privacy budget is depleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_DifferentialPrivacy_UsersNoisePerQuery")]
        public System.Int32? DifferentialPrivacy_UsersNoisePerQuery { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PrivacyBudgetTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreatePrivacyBudgetTemplateResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreatePrivacyBudgetTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PrivacyBudgetTemplate";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSPrivacyBudgetTemplate (CreatePrivacyBudgetTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreatePrivacyBudgetTemplateResponse, NewCRSPrivacyBudgetTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoRefresh = this.AutoRefresh;
            #if MODULAR
            if (this.AutoRefresh == null && ParameterWasBound(nameof(this.AutoRefresh)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoRefresh which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DifferentialPrivacy_Epsilon = this.DifferentialPrivacy_Epsilon;
            context.DifferentialPrivacy_UsersNoisePerQuery = this.DifferentialPrivacy_UsersNoisePerQuery;
            context.PrivacyBudgetType = this.PrivacyBudgetType;
            #if MODULAR
            if (this.PrivacyBudgetType == null && ParameterWasBound(nameof(this.PrivacyBudgetType)))
            {
                WriteWarning("You are passing $null as a value for parameter PrivacyBudgetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.CleanRooms.Model.CreatePrivacyBudgetTemplateRequest();
            
            if (cmdletContext.AutoRefresh != null)
            {
                request.AutoRefresh = cmdletContext.AutoRefresh;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            
             // populate Parameters
            var requestParametersIsNull = true;
            request.Parameters = new Amazon.CleanRooms.Model.PrivacyBudgetTemplateParametersInput();
            Amazon.CleanRooms.Model.DifferentialPrivacyTemplateParametersInput requestParameters_parameters_DifferentialPrivacy = null;
            
             // populate DifferentialPrivacy
            var requestParameters_parameters_DifferentialPrivacyIsNull = true;
            requestParameters_parameters_DifferentialPrivacy = new Amazon.CleanRooms.Model.DifferentialPrivacyTemplateParametersInput();
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
            if (cmdletContext.PrivacyBudgetType != null)
            {
                request.PrivacyBudgetType = cmdletContext.PrivacyBudgetType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CleanRooms.Model.CreatePrivacyBudgetTemplateResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreatePrivacyBudgetTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreatePrivacyBudgetTemplate");
            try
            {
                return client.CreatePrivacyBudgetTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CleanRooms.PrivacyBudgetTemplateAutoRefresh AutoRefresh { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.Int32? DifferentialPrivacy_Epsilon { get; set; }
            public System.Int32? DifferentialPrivacy_UsersNoisePerQuery { get; set; }
            public Amazon.CleanRooms.PrivacyBudgetType PrivacyBudgetType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreatePrivacyBudgetTemplateResponse, NewCRSPrivacyBudgetTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PrivacyBudgetTemplate;
        }
        
    }
}
