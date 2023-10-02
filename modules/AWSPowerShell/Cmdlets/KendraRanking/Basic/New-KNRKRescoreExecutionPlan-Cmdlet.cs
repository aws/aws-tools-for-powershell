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
using Amazon.KendraRanking;
using Amazon.KendraRanking.Model;

namespace Amazon.PowerShell.Cmdlets.KNRK
{
    /// <summary>
    /// Creates a rescore execution plan. A rescore execution plan is an Amazon Kendra Intelligent
    /// Ranking resource used for provisioning the <code>Rescore</code> API. You set the number
    /// of capacity units that you require for Amazon Kendra Intelligent Ranking to rescore
    /// or re-rank a search service's results.
    /// 
    ///  
    /// <para>
    /// For an example of using the <code>CreateRescoreExecutionPlan</code> API, including
    /// using the Python and Java SDKs, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/search-service-rerank.html">Semantically
    /// ranking a search service's results</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KNRKRescoreExecutionPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KendraRanking.Model.CreateRescoreExecutionPlanResponse")]
    [AWSCmdlet("Calls the Amazon Kendra Intelligent Ranking CreateRescoreExecutionPlan API operation.", Operation = new[] {"CreateRescoreExecutionPlan"}, SelectReturnType = typeof(Amazon.KendraRanking.Model.CreateRescoreExecutionPlanResponse))]
    [AWSCmdletOutput("Amazon.KendraRanking.Model.CreateRescoreExecutionPlanResponse",
        "This cmdlet returns an Amazon.KendraRanking.Model.CreateRescoreExecutionPlanResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKNRKRescoreExecutionPlanCmdlet : AmazonKendraRankingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the rescore execution plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the rescore execution plan.</para>
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
        
        #region Parameter CapacityUnits_RescoreCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The amount of extra capacity for your rescore execution plan.</para><para>A single extra capacity unit for a rescore execution plan provides 0.01 rescore requests
        /// per second. You can add up to 1000 extra capacity units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityUnits_RescoreCapacityUnits")]
        public System.Int32? CapacityUnits_RescoreCapacityUnit { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that identify or categorize your rescore execution plan.
        /// You can also use tags to help control access to the rescore execution plan. Tag keys
        /// and values can consist of Unicode letters, digits, white space, and any of the following
        /// symbols: _ . : / = + - @.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KendraRanking.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that you provide to identify the request to create a rescore execution plan.
        /// Multiple calls to the <code>CreateRescoreExecutionPlanRequest</code> API with the
        /// same client token will create only one rescore execution plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KendraRanking.Model.CreateRescoreExecutionPlanResponse).
        /// Specifying the name of a property of type Amazon.KendraRanking.Model.CreateRescoreExecutionPlanResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KNRKRescoreExecutionPlan (CreateRescoreExecutionPlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KendraRanking.Model.CreateRescoreExecutionPlanResponse, NewKNRKRescoreExecutionPlanCmdlet>(Select) ??
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
            context.CapacityUnits_RescoreCapacityUnit = this.CapacityUnits_RescoreCapacityUnit;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.KendraRanking.Model.Tag>(this.Tag);
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
            var request = new Amazon.KendraRanking.Model.CreateRescoreExecutionPlanRequest();
            
            
             // populate CapacityUnits
            var requestCapacityUnitsIsNull = true;
            request.CapacityUnits = new Amazon.KendraRanking.Model.CapacityUnitsConfiguration();
            System.Int32? requestCapacityUnits_capacityUnits_RescoreCapacityUnit = null;
            if (cmdletContext.CapacityUnits_RescoreCapacityUnit != null)
            {
                requestCapacityUnits_capacityUnits_RescoreCapacityUnit = cmdletContext.CapacityUnits_RescoreCapacityUnit.Value;
            }
            if (requestCapacityUnits_capacityUnits_RescoreCapacityUnit != null)
            {
                request.CapacityUnits.RescoreCapacityUnits = requestCapacityUnits_capacityUnits_RescoreCapacityUnit.Value;
                requestCapacityUnitsIsNull = false;
            }
             // determine if request.CapacityUnits should be set to null
            if (requestCapacityUnitsIsNull)
            {
                request.CapacityUnits = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.KendraRanking.Model.CreateRescoreExecutionPlanResponse CallAWSServiceOperation(IAmazonKendraRanking client, Amazon.KendraRanking.Model.CreateRescoreExecutionPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra Intelligent Ranking", "CreateRescoreExecutionPlan");
            try
            {
                #if DESKTOP
                return client.CreateRescoreExecutionPlan(request);
                #elif CORECLR
                return client.CreateRescoreExecutionPlanAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? CapacityUnits_RescoreCapacityUnit { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.KendraRanking.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KendraRanking.Model.CreateRescoreExecutionPlanResponse, NewKNRKRescoreExecutionPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
