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
    /// Updates a rescore execution plan. A rescore execution plan is an Amazon Kendra Intelligent
    /// Ranking resource used for provisioning the <code>Rescore</code> API. You can update
    /// the number of capacity units you require for Amazon Kendra Intelligent Ranking to
    /// rescore or re-rank a search service's results.
    /// </summary>
    [Cmdlet("Update", "KNRKRescoreExecutionPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kendra Intelligent Ranking UpdateRescoreExecutionPlan API operation.", Operation = new[] {"UpdateRescoreExecutionPlan"}, SelectReturnType = typeof(Amazon.KendraRanking.Model.UpdateRescoreExecutionPlanResponse))]
    [AWSCmdletOutput("None or Amazon.KendraRanking.Model.UpdateRescoreExecutionPlanResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KendraRanking.Model.UpdateRescoreExecutionPlanResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKNRKRescoreExecutionPlanCmdlet : AmazonKendraRankingClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the rescore execution plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the rescore execution plan that you want to update.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A new name for the rescore execution plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KendraRanking.Model.UpdateRescoreExecutionPlanResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KNRKRescoreExecutionPlan (UpdateRescoreExecutionPlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KendraRanking.Model.UpdateRescoreExecutionPlanResponse, UpdateKNRKRescoreExecutionPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CapacityUnits_RescoreCapacityUnit = this.CapacityUnits_RescoreCapacityUnit;
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            
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
            var request = new Amazon.KendraRanking.Model.UpdateRescoreExecutionPlanRequest();
            
            
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
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.KendraRanking.Model.UpdateRescoreExecutionPlanResponse CallAWSServiceOperation(IAmazonKendraRanking client, Amazon.KendraRanking.Model.UpdateRescoreExecutionPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra Intelligent Ranking", "UpdateRescoreExecutionPlan");
            try
            {
                #if DESKTOP
                return client.UpdateRescoreExecutionPlan(request);
                #elif CORECLR
                return client.UpdateRescoreExecutionPlanAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.KendraRanking.Model.UpdateRescoreExecutionPlanResponse, UpdateKNRKRescoreExecutionPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
