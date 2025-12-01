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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Updates the properties of an existing recommender, allowing you to modify its configuration
    /// and description.
    /// </summary>
    [Cmdlet("Update", "CPFRecommender", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles UpdateRecommender API operation.", Operation = new[] {"UpdateRecommender"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.UpdateRecommenderResponse))]
    [AWSCmdletOutput("System.String or Amazon.CustomerProfiles.Model.UpdateRecommenderResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CustomerProfiles.Model.UpdateRecommenderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCPFRecommenderCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description to assign to the recommender.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter EventsConfig_EventParametersList
        /// <summary>
        /// <para>
        /// <para>A list of event parameters configurations that specify how different event types should
        /// be handled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommenderConfig_EventsConfig_EventParametersList")]
        public Amazon.CustomerProfiles.Model.EventParameters[] EventsConfig_EventParametersList { get; set; }
        #endregion
        
        #region Parameter RecommenderName
        /// <summary>
        /// <para>
        /// <para>The name of the recommender to update.</para>
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
        public System.String RecommenderName { get; set; }
        #endregion
        
        #region Parameter RecommenderConfig_TrainingFrequency
        /// <summary>
        /// <para>
        /// <para>How often the recommender should retrain its model with new data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RecommenderConfig_TrainingFrequency { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommenderName'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.UpdateRecommenderResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.UpdateRecommenderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommenderName";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecommenderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CPFRecommender (UpdateRecommender)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.UpdateRecommenderResponse, UpdateCPFRecommenderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EventsConfig_EventParametersList != null)
            {
                context.EventsConfig_EventParametersList = new List<Amazon.CustomerProfiles.Model.EventParameters>(this.EventsConfig_EventParametersList);
            }
            context.RecommenderConfig_TrainingFrequency = this.RecommenderConfig_TrainingFrequency;
            context.RecommenderName = this.RecommenderName;
            #if MODULAR
            if (this.RecommenderName == null && ParameterWasBound(nameof(this.RecommenderName)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommenderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CustomerProfiles.Model.UpdateRecommenderRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate RecommenderConfig
            var requestRecommenderConfigIsNull = true;
            request.RecommenderConfig = new Amazon.CustomerProfiles.Model.RecommenderConfig();
            System.Int32? requestRecommenderConfig_recommenderConfig_TrainingFrequency = null;
            if (cmdletContext.RecommenderConfig_TrainingFrequency != null)
            {
                requestRecommenderConfig_recommenderConfig_TrainingFrequency = cmdletContext.RecommenderConfig_TrainingFrequency.Value;
            }
            if (requestRecommenderConfig_recommenderConfig_TrainingFrequency != null)
            {
                request.RecommenderConfig.TrainingFrequency = requestRecommenderConfig_recommenderConfig_TrainingFrequency.Value;
                requestRecommenderConfigIsNull = false;
            }
            Amazon.CustomerProfiles.Model.EventsConfig requestRecommenderConfig_recommenderConfig_EventsConfig = null;
            
             // populate EventsConfig
            var requestRecommenderConfig_recommenderConfig_EventsConfigIsNull = true;
            requestRecommenderConfig_recommenderConfig_EventsConfig = new Amazon.CustomerProfiles.Model.EventsConfig();
            List<Amazon.CustomerProfiles.Model.EventParameters> requestRecommenderConfig_recommenderConfig_EventsConfig_eventsConfig_EventParametersList = null;
            if (cmdletContext.EventsConfig_EventParametersList != null)
            {
                requestRecommenderConfig_recommenderConfig_EventsConfig_eventsConfig_EventParametersList = cmdletContext.EventsConfig_EventParametersList;
            }
            if (requestRecommenderConfig_recommenderConfig_EventsConfig_eventsConfig_EventParametersList != null)
            {
                requestRecommenderConfig_recommenderConfig_EventsConfig.EventParametersList = requestRecommenderConfig_recommenderConfig_EventsConfig_eventsConfig_EventParametersList;
                requestRecommenderConfig_recommenderConfig_EventsConfigIsNull = false;
            }
             // determine if requestRecommenderConfig_recommenderConfig_EventsConfig should be set to null
            if (requestRecommenderConfig_recommenderConfig_EventsConfigIsNull)
            {
                requestRecommenderConfig_recommenderConfig_EventsConfig = null;
            }
            if (requestRecommenderConfig_recommenderConfig_EventsConfig != null)
            {
                request.RecommenderConfig.EventsConfig = requestRecommenderConfig_recommenderConfig_EventsConfig;
                requestRecommenderConfigIsNull = false;
            }
             // determine if request.RecommenderConfig should be set to null
            if (requestRecommenderConfigIsNull)
            {
                request.RecommenderConfig = null;
            }
            if (cmdletContext.RecommenderName != null)
            {
                request.RecommenderName = cmdletContext.RecommenderName;
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
        
        private Amazon.CustomerProfiles.Model.UpdateRecommenderResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.UpdateRecommenderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "UpdateRecommender");
            try
            {
                #if DESKTOP
                return client.UpdateRecommender(request);
                #elif CORECLR
                return client.UpdateRecommenderAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DomainName { get; set; }
            public List<Amazon.CustomerProfiles.Model.EventParameters> EventsConfig_EventParametersList { get; set; }
            public System.Int32? RecommenderConfig_TrainingFrequency { get; set; }
            public System.String RecommenderName { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.UpdateRecommenderResponse, UpdateCPFRecommenderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommenderName;
        }
        
    }
}
