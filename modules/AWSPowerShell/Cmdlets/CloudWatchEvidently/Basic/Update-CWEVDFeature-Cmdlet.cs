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
using Amazon.CloudWatchEvidently;
using Amazon.CloudWatchEvidently.Model;

namespace Amazon.PowerShell.Cmdlets.CWEVD
{
    /// <summary>
    /// Updates an existing feature.
    /// 
    ///  
    /// <para>
    /// You can't use this operation to update the tags of an existing feature. Instead, use
    /// <a href="https://docs.aws.amazon.com/cloudwatchevidently/latest/APIReference/API_TagResource.html">TagResource</a>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CWEVDFeature", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvidently.Model.Feature")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently UpdateFeature API operation.", Operation = new[] {"UpdateFeature"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.UpdateFeatureResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.Feature or Amazon.CloudWatchEvidently.Model.UpdateFeatureResponse",
        "This cmdlet returns an Amazon.CloudWatchEvidently.Model.Feature object.",
        "The service call response (type Amazon.CloudWatchEvidently.Model.UpdateFeatureResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCWEVDFeatureCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddOrUpdateVariation
        /// <summary>
        /// <para>
        /// <para>To update variation configurations for this feature, or add new ones, specify this
        /// structure. In this array, include any variations that you want to add or update. If
        /// the array includes a variation name that already exists for this feature, it is updated.
        /// If it includes a new variation name, it is added as a new variation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddOrUpdateVariations")]
        public Amazon.CloudWatchEvidently.Model.VariationConfig[] AddOrUpdateVariation { get; set; }
        #endregion
        
        #region Parameter DefaultVariation
        /// <summary>
        /// <para>
        /// <para>The name of the variation to use as the default variation. The default variation is
        /// served to users who are not allocated to any ongoing launches or experiments of this
        /// feature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultVariation { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the feature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EntityOverride
        /// <summary>
        /// <para>
        /// <para>Specified users that should always be served a specific variation of a feature. Each
        /// user is specified by a key-value pair . For each key, specify a user by entering their
        /// user ID, account ID, or some other identifier. For the value, specify the name of
        /// the variation that they are to be served.</para><para>This parameter is limited to 2500 overrides or a total of 40KB. The 40KB limit includes
        /// an overhead of 6 bytes per override.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityOverrides")]
        public System.Collections.Hashtable EntityOverride { get; set; }
        #endregion
        
        #region Parameter EvaluationStrategy
        /// <summary>
        /// <para>
        /// <para>Specify <c>ALL_RULES</c> to activate the traffic allocation specified by any ongoing
        /// launches or experiments. Specify <c>DEFAULT_VARIATION</c> to serve the default variation
        /// to all users instead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchEvidently.FeatureEvaluationStrategy")]
        public Amazon.CloudWatchEvidently.FeatureEvaluationStrategy EvaluationStrategy { get; set; }
        #endregion
        
        #region Parameter Feature
        /// <summary>
        /// <para>
        /// <para>The name of the feature to be updated.</para>
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
        public System.String Feature { get; set; }
        #endregion
        
        #region Parameter Project
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the project that contains the feature to be updated.</para>
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
        public System.String Project { get; set; }
        #endregion
        
        #region Parameter RemoveVariation
        /// <summary>
        /// <para>
        /// <para>Removes a variation from the feature. If the variation you specify doesn't exist,
        /// then this makes no change and does not report an error.</para><para>This operation fails if you try to remove a variation that is part of an ongoing launch
        /// or experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveVariations")]
        public System.String[] RemoveVariation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Feature'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.UpdateFeatureResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.UpdateFeatureResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Feature";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Feature), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWEVDFeature (UpdateFeature)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.UpdateFeatureResponse, UpdateCWEVDFeatureCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddOrUpdateVariation != null)
            {
                context.AddOrUpdateVariation = new List<Amazon.CloudWatchEvidently.Model.VariationConfig>(this.AddOrUpdateVariation);
            }
            context.DefaultVariation = this.DefaultVariation;
            context.Description = this.Description;
            if (this.EntityOverride != null)
            {
                context.EntityOverride = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EntityOverride.Keys)
                {
                    context.EntityOverride.Add((String)hashKey, (System.String)(this.EntityOverride[hashKey]));
                }
            }
            context.EvaluationStrategy = this.EvaluationStrategy;
            context.Feature = this.Feature;
            #if MODULAR
            if (this.Feature == null && ParameterWasBound(nameof(this.Feature)))
            {
                WriteWarning("You are passing $null as a value for parameter Feature which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Project = this.Project;
            #if MODULAR
            if (this.Project == null && ParameterWasBound(nameof(this.Project)))
            {
                WriteWarning("You are passing $null as a value for parameter Project which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RemoveVariation != null)
            {
                context.RemoveVariation = new List<System.String>(this.RemoveVariation);
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
            var request = new Amazon.CloudWatchEvidently.Model.UpdateFeatureRequest();
            
            if (cmdletContext.AddOrUpdateVariation != null)
            {
                request.AddOrUpdateVariations = cmdletContext.AddOrUpdateVariation;
            }
            if (cmdletContext.DefaultVariation != null)
            {
                request.DefaultVariation = cmdletContext.DefaultVariation;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EntityOverride != null)
            {
                request.EntityOverrides = cmdletContext.EntityOverride;
            }
            if (cmdletContext.EvaluationStrategy != null)
            {
                request.EvaluationStrategy = cmdletContext.EvaluationStrategy;
            }
            if (cmdletContext.Feature != null)
            {
                request.Feature = cmdletContext.Feature;
            }
            if (cmdletContext.Project != null)
            {
                request.Project = cmdletContext.Project;
            }
            if (cmdletContext.RemoveVariation != null)
            {
                request.RemoveVariations = cmdletContext.RemoveVariation;
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
        
        private Amazon.CloudWatchEvidently.Model.UpdateFeatureResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.UpdateFeatureRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "UpdateFeature");
            try
            {
                #if DESKTOP
                return client.UpdateFeature(request);
                #elif CORECLR
                return client.UpdateFeatureAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudWatchEvidently.Model.VariationConfig> AddOrUpdateVariation { get; set; }
            public System.String DefaultVariation { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> EntityOverride { get; set; }
            public Amazon.CloudWatchEvidently.FeatureEvaluationStrategy EvaluationStrategy { get; set; }
            public System.String Feature { get; set; }
            public System.String Project { get; set; }
            public List<System.String> RemoveVariation { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.UpdateFeatureResponse, UpdateCWEVDFeatureCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Feature;
        }
        
    }
}
