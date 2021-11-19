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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates a dashboard in an Amazon Web Services account.
    /// 
    ///  <note><para>
    /// Updating a Dashboard creates a new dashboard version but does not immediately publish
    /// the new version. You can update the published version of a dashboard by using the
    /// <code><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_UpdateDashboardPublishedVersion.html">UpdateDashboardPublishedVersion</a></code> API operation.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "QSDashboard", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateDashboardResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateDashboard API operation.", Operation = new[] {"UpdateDashboard"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateDashboardResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateDashboardResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateDashboardResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateQSDashboardCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        #region Parameter SourceTemplate_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceEntity_SourceTemplate_Arn")]
        public System.String SourceTemplate_Arn { get; set; }
        #endregion
        
        #region Parameter AdHocFilteringOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>Availability status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_AdHocFilteringOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior AdHocFilteringOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter ExportToCSVOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>Availability status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_ExportToCSVOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior ExportToCSVOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the dashboard that you're
        /// updating.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter DashboardId
        /// <summary>
        /// <para>
        /// <para>The ID for the dashboard.</para>
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
        public System.String DashboardId { get; set; }
        #endregion
        
        #region Parameter SourceTemplate_DataSetReference
        /// <summary>
        /// <para>
        /// <para>Dataset references.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceEntity_SourceTemplate_DataSetReferences")]
        public Amazon.QuickSight.Model.DataSetReference[] SourceTemplate_DataSetReference { get; set; }
        #endregion
        
        #region Parameter Parameters_DateTimeParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of date-time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_DateTimeParameters")]
        public Amazon.QuickSight.Model.DateTimeParameter[] Parameters_DateTimeParameter { get; set; }
        #endregion
        
        #region Parameter Parameters_DecimalParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of decimal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_DecimalParameters")]
        public Amazon.QuickSight.Model.DecimalParameter[] Parameters_DecimalParameter { get; set; }
        #endregion
        
        #region Parameter Parameters_IntegerParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of integer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_IntegerParameters")]
        public Amazon.QuickSight.Model.IntegerParameter[] Parameters_IntegerParameter { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The display name of the dashboard.</para>
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
        
        #region Parameter Parameters_StringParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_StringParameters")]
        public Amazon.QuickSight.Model.StringParameter[] Parameters_StringParameter { get; set; }
        #endregion
        
        #region Parameter ThemeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the theme that is being used for this dashboard.
        /// If you add a value for this field, it overrides the value that was originally associated
        /// with the entity. The theme ARN must exist in the same Amazon Web Services account
        /// where you create the dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThemeArn { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>A description for the first version of the dashboard being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionDescription { get; set; }
        #endregion
        
        #region Parameter SheetControlsOption_VisibilityState
        /// <summary>
        /// <para>
        /// <para>Visibility state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_SheetControlsOption_VisibilityState")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardUIState")]
        public Amazon.QuickSight.DashboardUIState SheetControlsOption_VisibilityState { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateDashboardResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateDashboardResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AwsAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AwsAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSDashboard (UpdateDashboard)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateDashboardResponse, UpdateQSDashboardCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AwsAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DashboardId = this.DashboardId;
            #if MODULAR
            if (this.DashboardId == null && ParameterWasBound(nameof(this.DashboardId)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AdHocFilteringOption_AvailabilityStatus = this.AdHocFilteringOption_AvailabilityStatus;
            context.ExportToCSVOption_AvailabilityStatus = this.ExportToCSVOption_AvailabilityStatus;
            context.SheetControlsOption_VisibilityState = this.SheetControlsOption_VisibilityState;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameters_DateTimeParameter != null)
            {
                context.Parameters_DateTimeParameter = new List<Amazon.QuickSight.Model.DateTimeParameter>(this.Parameters_DateTimeParameter);
            }
            if (this.Parameters_DecimalParameter != null)
            {
                context.Parameters_DecimalParameter = new List<Amazon.QuickSight.Model.DecimalParameter>(this.Parameters_DecimalParameter);
            }
            if (this.Parameters_IntegerParameter != null)
            {
                context.Parameters_IntegerParameter = new List<Amazon.QuickSight.Model.IntegerParameter>(this.Parameters_IntegerParameter);
            }
            if (this.Parameters_StringParameter != null)
            {
                context.Parameters_StringParameter = new List<Amazon.QuickSight.Model.StringParameter>(this.Parameters_StringParameter);
            }
            context.SourceTemplate_Arn = this.SourceTemplate_Arn;
            if (this.SourceTemplate_DataSetReference != null)
            {
                context.SourceTemplate_DataSetReference = new List<Amazon.QuickSight.Model.DataSetReference>(this.SourceTemplate_DataSetReference);
            }
            context.ThemeArn = this.ThemeArn;
            context.VersionDescription = this.VersionDescription;
            
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
            var request = new Amazon.QuickSight.Model.UpdateDashboardRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.DashboardId != null)
            {
                request.DashboardId = cmdletContext.DashboardId;
            }
            
             // populate DashboardPublishOptions
            var requestDashboardPublishOptionsIsNull = true;
            request.DashboardPublishOptions = new Amazon.QuickSight.Model.DashboardPublishOptions();
            Amazon.QuickSight.Model.AdHocFilteringOption requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption = null;
            
             // populate AdHocFilteringOption
            var requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption = new Amazon.QuickSight.Model.AdHocFilteringOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption_adHocFilteringOption_AvailabilityStatus = null;
            if (cmdletContext.AdHocFilteringOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption_adHocFilteringOption_AvailabilityStatus = cmdletContext.AdHocFilteringOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption_adHocFilteringOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption_adHocFilteringOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption != null)
            {
                request.DashboardPublishOptions.AdHocFilteringOption = requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.ExportToCSVOption requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption = null;
            
             // populate ExportToCSVOption
            var requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption = new Amazon.QuickSight.Model.ExportToCSVOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption_exportToCSVOption_AvailabilityStatus = null;
            if (cmdletContext.ExportToCSVOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption_exportToCSVOption_AvailabilityStatus = cmdletContext.ExportToCSVOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption_exportToCSVOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption_exportToCSVOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption != null)
            {
                request.DashboardPublishOptions.ExportToCSVOption = requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.SheetControlsOption requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption = null;
            
             // populate SheetControlsOption
            var requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption = new Amazon.QuickSight.Model.SheetControlsOption();
            Amazon.QuickSight.DashboardUIState requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption_sheetControlsOption_VisibilityState = null;
            if (cmdletContext.SheetControlsOption_VisibilityState != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption_sheetControlsOption_VisibilityState = cmdletContext.SheetControlsOption_VisibilityState;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption_sheetControlsOption_VisibilityState != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption.VisibilityState = requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption_sheetControlsOption_VisibilityState;
                requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption != null)
            {
                request.DashboardPublishOptions.SheetControlsOption = requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption;
                requestDashboardPublishOptionsIsNull = false;
            }
             // determine if request.DashboardPublishOptions should be set to null
            if (requestDashboardPublishOptionsIsNull)
            {
                request.DashboardPublishOptions = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Parameters
            var requestParametersIsNull = true;
            request.Parameters = new Amazon.QuickSight.Model.Parameters();
            List<Amazon.QuickSight.Model.DateTimeParameter> requestParameters_parameters_DateTimeParameter = null;
            if (cmdletContext.Parameters_DateTimeParameter != null)
            {
                requestParameters_parameters_DateTimeParameter = cmdletContext.Parameters_DateTimeParameter;
            }
            if (requestParameters_parameters_DateTimeParameter != null)
            {
                request.Parameters.DateTimeParameters = requestParameters_parameters_DateTimeParameter;
                requestParametersIsNull = false;
            }
            List<Amazon.QuickSight.Model.DecimalParameter> requestParameters_parameters_DecimalParameter = null;
            if (cmdletContext.Parameters_DecimalParameter != null)
            {
                requestParameters_parameters_DecimalParameter = cmdletContext.Parameters_DecimalParameter;
            }
            if (requestParameters_parameters_DecimalParameter != null)
            {
                request.Parameters.DecimalParameters = requestParameters_parameters_DecimalParameter;
                requestParametersIsNull = false;
            }
            List<Amazon.QuickSight.Model.IntegerParameter> requestParameters_parameters_IntegerParameter = null;
            if (cmdletContext.Parameters_IntegerParameter != null)
            {
                requestParameters_parameters_IntegerParameter = cmdletContext.Parameters_IntegerParameter;
            }
            if (requestParameters_parameters_IntegerParameter != null)
            {
                request.Parameters.IntegerParameters = requestParameters_parameters_IntegerParameter;
                requestParametersIsNull = false;
            }
            List<Amazon.QuickSight.Model.StringParameter> requestParameters_parameters_StringParameter = null;
            if (cmdletContext.Parameters_StringParameter != null)
            {
                requestParameters_parameters_StringParameter = cmdletContext.Parameters_StringParameter;
            }
            if (requestParameters_parameters_StringParameter != null)
            {
                request.Parameters.StringParameters = requestParameters_parameters_StringParameter;
                requestParametersIsNull = false;
            }
             // determine if request.Parameters should be set to null
            if (requestParametersIsNull)
            {
                request.Parameters = null;
            }
            
             // populate SourceEntity
            var requestSourceEntityIsNull = true;
            request.SourceEntity = new Amazon.QuickSight.Model.DashboardSourceEntity();
            Amazon.QuickSight.Model.DashboardSourceTemplate requestSourceEntity_sourceEntity_SourceTemplate = null;
            
             // populate SourceTemplate
            var requestSourceEntity_sourceEntity_SourceTemplateIsNull = true;
            requestSourceEntity_sourceEntity_SourceTemplate = new Amazon.QuickSight.Model.DashboardSourceTemplate();
            System.String requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn = null;
            if (cmdletContext.SourceTemplate_Arn != null)
            {
                requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn = cmdletContext.SourceTemplate_Arn;
            }
            if (requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn != null)
            {
                requestSourceEntity_sourceEntity_SourceTemplate.Arn = requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn;
                requestSourceEntity_sourceEntity_SourceTemplateIsNull = false;
            }
            List<Amazon.QuickSight.Model.DataSetReference> requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_DataSetReference = null;
            if (cmdletContext.SourceTemplate_DataSetReference != null)
            {
                requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_DataSetReference = cmdletContext.SourceTemplate_DataSetReference;
            }
            if (requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_DataSetReference != null)
            {
                requestSourceEntity_sourceEntity_SourceTemplate.DataSetReferences = requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_DataSetReference;
                requestSourceEntity_sourceEntity_SourceTemplateIsNull = false;
            }
             // determine if requestSourceEntity_sourceEntity_SourceTemplate should be set to null
            if (requestSourceEntity_sourceEntity_SourceTemplateIsNull)
            {
                requestSourceEntity_sourceEntity_SourceTemplate = null;
            }
            if (requestSourceEntity_sourceEntity_SourceTemplate != null)
            {
                request.SourceEntity.SourceTemplate = requestSourceEntity_sourceEntity_SourceTemplate;
                requestSourceEntityIsNull = false;
            }
             // determine if request.SourceEntity should be set to null
            if (requestSourceEntityIsNull)
            {
                request.SourceEntity = null;
            }
            if (cmdletContext.ThemeArn != null)
            {
                request.ThemeArn = cmdletContext.ThemeArn;
            }
            if (cmdletContext.VersionDescription != null)
            {
                request.VersionDescription = cmdletContext.VersionDescription;
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
        
        private Amazon.QuickSight.Model.UpdateDashboardResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateDashboardRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateDashboard");
            try
            {
                #if DESKTOP
                return client.UpdateDashboard(request);
                #elif CORECLR
                return client.UpdateDashboardAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String DashboardId { get; set; }
            public Amazon.QuickSight.DashboardBehavior AdHocFilteringOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardBehavior ExportToCSVOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardUIState SheetControlsOption_VisibilityState { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.QuickSight.Model.DateTimeParameter> Parameters_DateTimeParameter { get; set; }
            public List<Amazon.QuickSight.Model.DecimalParameter> Parameters_DecimalParameter { get; set; }
            public List<Amazon.QuickSight.Model.IntegerParameter> Parameters_IntegerParameter { get; set; }
            public List<Amazon.QuickSight.Model.StringParameter> Parameters_StringParameter { get; set; }
            public System.String SourceTemplate_Arn { get; set; }
            public List<Amazon.QuickSight.Model.DataSetReference> SourceTemplate_DataSetReference { get; set; }
            public System.String ThemeArn { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateDashboardResponse, UpdateQSDashboardCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
