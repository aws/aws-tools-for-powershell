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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Creates a recommender
    /// </summary>
    [Cmdlet("New", "CPFRecommender", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.CreateRecommenderResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles CreateRecommender API operation.", Operation = new[] {"CreateRecommender"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.CreateRecommenderResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.CreateRecommenderResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.CreateRecommenderResponse object containing multiple properties."
    )]
    public partial class NewCPFRecommenderCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the domain object type.</para>
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
        /// be handled.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommenderConfig_EventsConfig_EventParametersList")]
        public Amazon.CustomerProfiles.Model.EventParameters[] EventsConfig_EventParametersList { get; set; }
        #endregion
        
        #region Parameter RecommenderName
        /// <summary>
        /// <para>
        /// <para>The name of the recommender.</para>
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
        
        #region Parameter RecommenderRecipeName
        /// <summary>
        /// <para>
        /// <para>The name of the recommeder recipe.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CustomerProfiles.RecommenderRecipeName")]
        public Amazon.CustomerProfiles.RecommenderRecipeName RecommenderRecipeName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para><para />
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.CreateRecommenderResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.CreateRecommenderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecommenderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CPFRecommender (CreateRecommender)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.CreateRecommenderResponse, NewCPFRecommenderCmdlet>(Select) ??
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
            context.RecommenderRecipeName = this.RecommenderRecipeName;
            #if MODULAR
            if (this.RecommenderRecipeName == null && ParameterWasBound(nameof(this.RecommenderRecipeName)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommenderRecipeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CustomerProfiles.Model.CreateRecommenderRequest();
            
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
            if (cmdletContext.RecommenderRecipeName != null)
            {
                request.RecommenderRecipeName = cmdletContext.RecommenderRecipeName;
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
        
        private Amazon.CustomerProfiles.Model.CreateRecommenderResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.CreateRecommenderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "CreateRecommender");
            try
            {
                return client.CreateRecommenderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CustomerProfiles.RecommenderRecipeName RecommenderRecipeName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.CreateRecommenderResponse, NewCPFRecommenderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
