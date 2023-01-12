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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a new analysis rule for a configured table. Currently, only one analysis rule
    /// can be created for a given configured table.
    /// </summary>
    [Cmdlet("New", "CRSConfiguredTableAnalysisRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.ConfiguredTableAnalysisRule")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateConfiguredTableAnalysisRule API operation.", Operation = new[] {"CreateConfiguredTableAnalysisRule"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.ConfiguredTableAnalysisRule or Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.ConfiguredTableAnalysisRule object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCRSConfiguredTableAnalysisRuleCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        #region Parameter Aggregation_AggregateColumn
        /// <summary>
        /// <para>
        /// <para>The columns that query runners are allowed to use in aggregation queries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_AggregateColumns")]
        public Amazon.CleanRooms.Model.AggregateColumn[] Aggregation_AggregateColumn { get; set; }
        #endregion
        
        #region Parameter AnalysisRuleType
        /// <summary>
        /// <para>
        /// <para>The type of analysis rule. Valid values are AGGREGATION and LIST.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.ConfiguredTableAnalysisRuleType")]
        public Amazon.CleanRooms.ConfiguredTableAnalysisRuleType AnalysisRuleType { get; set; }
        #endregion
        
        #region Parameter ConfiguredTableIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the configured table to create the analysis rule for. Currently
        /// accepts the configured table ID. </para>
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
        public System.String ConfiguredTableIdentifier { get; set; }
        #endregion
        
        #region Parameter Aggregation_DimensionColumn
        /// <summary>
        /// <para>
        /// <para>The columns that query runners are allowed to select, group by, or filter by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_DimensionColumns")]
        public System.String[] Aggregation_DimensionColumn { get; set; }
        #endregion
        
        #region Parameter Aggregation_JoinColumn
        /// <summary>
        /// <para>
        /// <para>Columns in configured table that can be used in join statements and/or as aggregate
        /// columns. They can never be outputted directly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_JoinColumns")]
        public System.String[] Aggregation_JoinColumn { get; set; }
        #endregion
        
        #region Parameter List_JoinColumn
        /// <summary>
        /// <para>
        /// <para>Columns that can be used to join a configured table with the table of the member who
        /// can query and another members' configured tables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_List_JoinColumns")]
        public System.String[] List_JoinColumn { get; set; }
        #endregion
        
        #region Parameter Aggregation_JoinRequired
        /// <summary>
        /// <para>
        /// <para>Control that requires member who runs query to do a join with their configured table
        /// and/or other configured table in query</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_JoinRequired")]
        [AWSConstantClassSource("Amazon.CleanRooms.JoinRequiredOption")]
        public Amazon.CleanRooms.JoinRequiredOption Aggregation_JoinRequired { get; set; }
        #endregion
        
        #region Parameter List_ListColumn
        /// <summary>
        /// <para>
        /// <para>Columns that can be listed in the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_List_ListColumns")]
        public System.String[] List_ListColumn { get; set; }
        #endregion
        
        #region Parameter Aggregation_OutputConstraint
        /// <summary>
        /// <para>
        /// <para>Columns that must meet a specific threshold value (after an aggregation function is
        /// applied to it) for each output row to be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_OutputConstraints")]
        public Amazon.CleanRooms.Model.AggregationConstraint[] Aggregation_OutputConstraint { get; set; }
        #endregion
        
        #region Parameter Aggregation_ScalarFunction
        /// <summary>
        /// <para>
        /// <para>Set of scalar functions that are allowed to be used on dimension columns and the output
        /// of aggregation of metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisRulePolicy_V1_Aggregation_ScalarFunctions")]
        public System.String[] Aggregation_ScalarFunction { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnalysisRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnalysisRule";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfiguredTableIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfiguredTableIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfiguredTableIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfiguredTableIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSConfiguredTableAnalysisRule (CreateConfiguredTableAnalysisRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse, NewCRSConfiguredTableAnalysisRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfiguredTableIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Aggregation_AggregateColumn != null)
            {
                context.Aggregation_AggregateColumn = new List<Amazon.CleanRooms.Model.AggregateColumn>(this.Aggregation_AggregateColumn);
            }
            if (this.Aggregation_DimensionColumn != null)
            {
                context.Aggregation_DimensionColumn = new List<System.String>(this.Aggregation_DimensionColumn);
            }
            if (this.Aggregation_JoinColumn != null)
            {
                context.Aggregation_JoinColumn = new List<System.String>(this.Aggregation_JoinColumn);
            }
            context.Aggregation_JoinRequired = this.Aggregation_JoinRequired;
            if (this.Aggregation_OutputConstraint != null)
            {
                context.Aggregation_OutputConstraint = new List<Amazon.CleanRooms.Model.AggregationConstraint>(this.Aggregation_OutputConstraint);
            }
            if (this.Aggregation_ScalarFunction != null)
            {
                context.Aggregation_ScalarFunction = new List<System.String>(this.Aggregation_ScalarFunction);
            }
            if (this.List_JoinColumn != null)
            {
                context.List_JoinColumn = new List<System.String>(this.List_JoinColumn);
            }
            if (this.List_ListColumn != null)
            {
                context.List_ListColumn = new List<System.String>(this.List_ListColumn);
            }
            context.AnalysisRuleType = this.AnalysisRuleType;
            #if MODULAR
            if (this.AnalysisRuleType == null && ParameterWasBound(nameof(this.AnalysisRuleType)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisRuleType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfiguredTableIdentifier = this.ConfiguredTableIdentifier;
            #if MODULAR
            if (this.ConfiguredTableIdentifier == null && ParameterWasBound(nameof(this.ConfiguredTableIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredTableIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleRequest();
            
            
             // populate AnalysisRulePolicy
            var requestAnalysisRulePolicyIsNull = true;
            request.AnalysisRulePolicy = new Amazon.CleanRooms.Model.ConfiguredTableAnalysisRulePolicy();
            Amazon.CleanRooms.Model.ConfiguredTableAnalysisRulePolicyV1 requestAnalysisRulePolicy_analysisRulePolicy_V1 = null;
            
             // populate V1
            var requestAnalysisRulePolicy_analysisRulePolicy_V1IsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1 = new Amazon.CleanRooms.Model.ConfiguredTableAnalysisRulePolicyV1();
            Amazon.CleanRooms.Model.AnalysisRuleList requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List = null;
            
             // populate List
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List = new Amazon.CleanRooms.Model.AnalysisRuleList();
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_JoinColumn = null;
            if (cmdletContext.List_JoinColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_JoinColumn = cmdletContext.List_JoinColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_JoinColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List.JoinColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_JoinColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_ListIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_ListColumn = null;
            if (cmdletContext.List_ListColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_ListColumn = cmdletContext.List_ListColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_ListColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List.ListColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_List_list_ListColumn;
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
            Amazon.CleanRooms.Model.AnalysisRuleAggregation requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation = null;
            
             // populate Aggregation
            var requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = true;
            requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation = new Amazon.CleanRooms.Model.AnalysisRuleAggregation();
            List<Amazon.CleanRooms.Model.AggregateColumn> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AggregateColumn = null;
            if (cmdletContext.Aggregation_AggregateColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AggregateColumn = cmdletContext.Aggregation_AggregateColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AggregateColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.AggregateColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_AggregateColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_DimensionColumn = null;
            if (cmdletContext.Aggregation_DimensionColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_DimensionColumn = cmdletContext.Aggregation_DimensionColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_DimensionColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.DimensionColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_DimensionColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinColumn = null;
            if (cmdletContext.Aggregation_JoinColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinColumn = cmdletContext.Aggregation_JoinColumn;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinColumn != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.JoinColumns = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinColumn;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            Amazon.CleanRooms.JoinRequiredOption requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinRequired = null;
            if (cmdletContext.Aggregation_JoinRequired != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinRequired = cmdletContext.Aggregation_JoinRequired;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinRequired != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.JoinRequired = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_JoinRequired;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<Amazon.CleanRooms.Model.AggregationConstraint> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_OutputConstraint = null;
            if (cmdletContext.Aggregation_OutputConstraint != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_OutputConstraint = cmdletContext.Aggregation_OutputConstraint;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_OutputConstraint != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.OutputConstraints = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_OutputConstraint;
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_AggregationIsNull = false;
            }
            List<System.String> requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_ScalarFunction = null;
            if (cmdletContext.Aggregation_ScalarFunction != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_ScalarFunction = cmdletContext.Aggregation_ScalarFunction;
            }
            if (requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_ScalarFunction != null)
            {
                requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation.ScalarFunctions = requestAnalysisRulePolicy_analysisRulePolicy_V1_analysisRulePolicy_V1_Aggregation_aggregation_ScalarFunction;
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
            if (cmdletContext.ConfiguredTableIdentifier != null)
            {
                request.ConfiguredTableIdentifier = cmdletContext.ConfiguredTableIdentifier;
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
        
        private Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateConfiguredTableAnalysisRule");
            try
            {
                #if DESKTOP
                return client.CreateConfiguredTableAnalysisRule(request);
                #elif CORECLR
                return client.CreateConfiguredTableAnalysisRuleAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CleanRooms.Model.AggregateColumn> Aggregation_AggregateColumn { get; set; }
            public List<System.String> Aggregation_DimensionColumn { get; set; }
            public List<System.String> Aggregation_JoinColumn { get; set; }
            public Amazon.CleanRooms.JoinRequiredOption Aggregation_JoinRequired { get; set; }
            public List<Amazon.CleanRooms.Model.AggregationConstraint> Aggregation_OutputConstraint { get; set; }
            public List<System.String> Aggregation_ScalarFunction { get; set; }
            public List<System.String> List_JoinColumn { get; set; }
            public List<System.String> List_ListColumn { get; set; }
            public Amazon.CleanRooms.ConfiguredTableAnalysisRuleType AnalysisRuleType { get; set; }
            public System.String ConfiguredTableIdentifier { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateConfiguredTableAnalysisRuleResponse, NewCRSConfiguredTableAnalysisRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnalysisRule;
        }
        
    }
}
