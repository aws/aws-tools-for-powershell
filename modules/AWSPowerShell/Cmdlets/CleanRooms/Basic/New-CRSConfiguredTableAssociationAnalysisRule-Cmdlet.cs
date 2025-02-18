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

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a new analysis rule for an associated configured table.
    /// </summary>
    [Cmdlet("New", "CRSConfiguredTableAssociationAnalysisRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRule")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateConfiguredTableAssociationAnalysisRule API operation.", Operation = new[] {"CreateConfiguredTableAssociationAnalysisRule"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateConfiguredTableAssociationAnalysisRuleResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRule or Amazon.CleanRooms.Model.CreateConfiguredTableAssociationAnalysisRuleResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRule object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateConfiguredTableAssociationAnalysisRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRSConfiguredTableAssociationAnalysisRuleCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Aggregation_AllowedAdditionalAnalysis
        /// <summary>
        /// <para>
        /// <para> The list of resources or wildcards (ARNs) that are allowed to perform additional
        /// analysis on query output.</para><para>The <c>allowedAdditionalAnalyses</c> parameter is currently supported for the list
        /// analysis rule (<c>AnalysisRuleList</c>) and the custom analysis rule (<c>AnalysisRuleCustom</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_AllowedAdditionalAnalyses")]
        public System.String[] Aggregation_AllowedAdditionalAnalysis { get; set; }
        #endregion
        
        #region Parameter Custom_AllowedAdditionalAnalysis
        /// <summary>
        /// <para>
        /// <para> The list of resources or wildcards (ARNs) that are allowed to perform additional
        /// analysis on query output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_AllowedAdditionalAnalyses")]
        public System.String[] Custom_AllowedAdditionalAnalysis { get; set; }
        #endregion
        
        #region Parameter List_AllowedAdditionalAnalysis
        /// <summary>
        /// <para>
        /// <para> The list of resources or wildcards (ARNs) that are allowed to perform additional
        /// analysis on query output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_List_AllowedAdditionalAnalyses")]
        public System.String[] List_AllowedAdditionalAnalysis { get; set; }
        #endregion
        
        #region Parameter Aggregation_AllowedResultReceiver
        /// <summary>
        /// <para>
        /// <para> The list of collaboration members who are allowed to receive results of queries run
        /// with this configured table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_AllowedResultReceivers")]
        public System.String[] Aggregation_AllowedResultReceiver { get; set; }
        #endregion
        
        #region Parameter Custom_AllowedResultReceiver
        /// <summary>
        /// <para>
        /// <para> The list of collaboration members who are allowed to receive results of queries run
        /// with this configured table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Custom_AllowedResultReceivers")]
        public System.String[] Custom_AllowedResultReceiver { get; set; }
        #endregion
        
        #region Parameter List_AllowedResultReceiver
        /// <summary>
        /// <para>
        /// <para> The list of collaboration members who are allowed to receive results of queries run
        /// with this configured table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_List_AllowedResultReceivers")]
        public System.String[] List_AllowedResultReceiver { get; set; }
        #endregion
        
        #region Parameter AnalysisRuleType
        /// <summary>
        /// <para>
        /// <para> The type of analysis rule.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.ConfiguredTableAssociationAnalysisRuleType")]
        public Amazon.CleanRooms.ConfiguredTableAssociationAnalysisRuleType AnalysisRuleType { get; set; }
        #endregion
        
        #region Parameter ConfiguredTableAssociationIdentifier
        /// <summary>
        /// <para>
        /// <para> The unique ID for the configured table association. Currently accepts the configured
        /// table association ID.</para>
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
        public System.String ConfiguredTableAssociationIdentifier { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para> A unique identifier for the membership that the configured table association belongs
        /// to. Currently accepts the membership ID.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnalysisRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateConfiguredTableAssociationAnalysisRuleResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateConfiguredTableAssociationAnalysisRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnalysisRule";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfiguredTableAssociationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSConfiguredTableAssociationAnalysisRule (CreateConfiguredTableAssociationAnalysisRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateConfiguredTableAssociationAnalysisRuleResponse, NewCRSConfiguredTableAssociationAnalysisRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Aggregation_AllowedAdditionalAnalysis != null)
            {
                context.Aggregation_AllowedAdditionalAnalysis = new List<System.String>(this.Aggregation_AllowedAdditionalAnalysis);
            }
            if (this.Aggregation_AllowedResultReceiver != null)
            {
                context.Aggregation_AllowedResultReceiver = new List<System.String>(this.Aggregation_AllowedResultReceiver);
            }
            if (this.Custom_AllowedAdditionalAnalysis != null)
            {
                context.Custom_AllowedAdditionalAnalysis = new List<System.String>(this.Custom_AllowedAdditionalAnalysis);
            }
            if (this.Custom_AllowedResultReceiver != null)
            {
                context.Custom_AllowedResultReceiver = new List<System.String>(this.Custom_AllowedResultReceiver);
            }
            if (this.List_AllowedAdditionalAnalysis != null)
            {
                context.List_AllowedAdditionalAnalysis = new List<System.String>(this.List_AllowedAdditionalAnalysis);
            }
            if (this.List_AllowedResultReceiver != null)
            {
                context.List_AllowedResultReceiver = new List<System.String>(this.List_AllowedResultReceiver);
            }
            context.AnalysisRuleType = this.AnalysisRuleType;
            #if MODULAR
            if (this.AnalysisRuleType == null && ParameterWasBound(nameof(this.AnalysisRuleType)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisRuleType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfiguredTableAssociationIdentifier = this.ConfiguredTableAssociationIdentifier;
            #if MODULAR
            if (this.ConfiguredTableAssociationIdentifier == null && ParameterWasBound(nameof(this.ConfiguredTableAssociationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredTableAssociationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.CreateConfiguredTableAssociationAnalysisRuleRequest();
            
            
             // populate AnalysisRulePolicy
            var requestAnalysisRulePolicyIsNull = true;
            request.AnalysisRulePolicy = new Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRulePolicy();
            Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRulePolicyV1 requestAnalysisRulePolicy_analysisRulePolicy_V1 = null;
            
             // populate V1
            var requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1 = new Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRulePolicyV1();
            Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRuleAggregation requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation = null;
            
             // populate Aggregation
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation = new Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRuleAggregation();
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedAdditionalAnalysis = null;
            if (cmdletContext.Aggregation_AllowedAdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedAdditionalAnalysis = cmdletContext.Aggregation_AllowedAdditionalAnalysis;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedAdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.AllowedAdditionalAnalyses = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedAdditionalAnalysis;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedResultReceiver = null;
            if (cmdletContext.Aggregation_AllowedResultReceiver != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedResultReceiver = cmdletContext.Aggregation_AllowedResultReceiver;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedResultReceiver != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.AllowedResultReceivers = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AllowedResultReceiver;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
             // determine if requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation should be set to null
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation = null;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1.Aggregation = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation;
                requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull = false;
            }
            Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRuleCustom requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom = null;
            
             // populate Custom
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom = new Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRuleCustom();
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAdditionalAnalysis = null;
            if (cmdletContext.Custom_AllowedAdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAdditionalAnalysis = cmdletContext.Custom_AllowedAdditionalAnalysis;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AllowedAdditionalAnalyses = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedAdditionalAnalysis;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedResultReceiver = null;
            if (cmdletContext.Custom_AllowedResultReceiver != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedResultReceiver = cmdletContext.Custom_AllowedResultReceiver;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedResultReceiver != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom.AllowedResultReceivers = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom_custom_AllowedResultReceiver;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull = false;
            }
             // determine if requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom should be set to null
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_CustomIsNull)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom = null;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1.Custom = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Custom;
                requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull = false;
            }
            Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRuleList requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List = null;
            
             // populate List
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List = new Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRuleList();
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedAdditionalAnalysis = null;
            if (cmdletContext.List_AllowedAdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedAdditionalAnalysis = cmdletContext.List_AllowedAdditionalAnalysis;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedAdditionalAnalysis != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List.AllowedAdditionalAnalyses = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedAdditionalAnalysis;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedResultReceiver = null;
            if (cmdletContext.List_AllowedResultReceiver != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedResultReceiver = cmdletContext.List_AllowedResultReceiver;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedResultReceiver != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List.AllowedResultReceivers = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_AllowedResultReceiver;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull = false;
            }
             // determine if requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List should be set to null
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List = null;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1.List = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List;
                requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull = false;
            }
             // determine if requestAnalysisRulePolicy_analysisRulePolicy_V1 should be set to null
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1 = null;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1 != null)
            {
                request.AnalysisRulePolicy.V1 = requestAnalysisRulePolicy_analysisRulePolicy_V1;
                requestAnalysisRulePolicyIsNull = false;
            }
             // determine if request.AnalysisRulePolicy should be set to null
            if (requestAnalysisRulePolicyIsNull)
            {
                request.AnalysisRulePolicy = null;
            }
            if (cmdletContext.AnalysisRuleType != null)
            {
                request.AnalysisRuleType = cmdletContext.AnalysisRuleType;
            }
            if (cmdletContext.ConfiguredTableAssociationIdentifier != null)
            {
                request.ConfiguredTableAssociationIdentifier = cmdletContext.ConfiguredTableAssociationIdentifier;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
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
        
        private Amazon.CleanRooms.Model.CreateConfiguredTableAssociationAnalysisRuleResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateConfiguredTableAssociationAnalysisRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateConfiguredTableAssociationAnalysisRule");
            try
            {
                return client.CreateConfiguredTableAssociationAnalysisRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Aggregation_AllowedAdditionalAnalysis { get; set; }
            public List<System.String> Aggregation_AllowedResultReceiver { get; set; }
            public List<System.String> Custom_AllowedAdditionalAnalysis { get; set; }
            public List<System.String> Custom_AllowedResultReceiver { get; set; }
            public List<System.String> List_AllowedAdditionalAnalysis { get; set; }
            public List<System.String> List_AllowedResultReceiver { get; set; }
            public Amazon.CleanRooms.ConfiguredTableAssociationAnalysisRuleType AnalysisRuleType { get; set; }
            public System.String ConfiguredTableAssociationIdentifier { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateConfiguredTableAssociationAnalysisRuleResponse, NewCRSConfiguredTableAssociationAnalysisRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnalysisRule;
        }
        
    }
}
