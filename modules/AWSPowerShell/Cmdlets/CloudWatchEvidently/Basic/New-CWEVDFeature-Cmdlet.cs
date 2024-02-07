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
    /// Creates an Evidently <i>feature</i> that you want to launch or test. You can define
    /// up to five variations of a feature, and use these variations in your launches and
    /// experiments. A feature must be created in a project. For information about creating
    /// a project, see <a href="https://docs.aws.amazon.com/cloudwatchevidently/latest/APIReference/API_CreateProject.html">CreateProject</a>.
    /// 
    ///  
    /// <para>
    /// Don't use this operation to update an existing feature. Instead, use <a href="https://docs.aws.amazon.com/cloudwatchevidently/latest/APIReference/API_UpdateFeature.html">UpdateFeature</a>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWEVDFeature", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvidently.Model.Feature")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently CreateFeature API operation.", Operation = new[] {"CreateFeature"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.CreateFeatureResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.Feature or Amazon.CloudWatchEvidently.Model.CreateFeatureResponse",
        "This cmdlet returns an Amazon.CloudWatchEvidently.Model.Feature object.",
        "The service call response (type Amazon.CloudWatchEvidently.Model.CreateFeatureResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCWEVDFeatureCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefaultVariation
        /// <summary>
        /// <para>
        /// <para>The name of the variation to use as the default variation. The default variation is
        /// served to users who are not allocated to any ongoing launches or experiments of this
        /// feature.</para><para>This variation must also be listed in the <c>variations</c> structure.</para><para>If you omit <c>defaultVariation</c>, the first variation listed in the <c>variations</c>
        /// structure is used as the default variation.</para>
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
        /// <para>Specify users that should always be served a specific variation of a feature. Each
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the new feature.</para>
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
        
        #region Parameter Project
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the project that is to contain the new feature.</para>
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
        public System.String Project { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Assigns one or more tags (key-value pairs) to the feature.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions by granting a user permission to access or change only resources
        /// with certain tag values.</para><para>Tags don't have any semantic meaning to Amazon Web Services and are interpreted strictly
        /// as strings of characters.</para><para>You can associate as many as 50 tags with a feature.</para><para>For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Variation
        /// <summary>
        /// <para>
        /// <para>An array of structures that contain the configuration of the feature's different variations.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Variations")]
        public Amazon.CloudWatchEvidently.Model.VariationConfig[] Variation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Feature'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.CreateFeatureResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.CreateFeatureResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Feature";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Project parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Project' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Project' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWEVDFeature (CreateFeature)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.CreateFeatureResponse, NewCWEVDFeatureCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Project;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Project = this.Project;
            #if MODULAR
            if (this.Project == null && ParameterWasBound(nameof(this.Project)))
            {
                WriteWarning("You are passing $null as a value for parameter Project which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            if (this.Variation != null)
            {
                context.Variation = new List<Amazon.CloudWatchEvidently.Model.VariationConfig>(this.Variation);
            }
            #if MODULAR
            if (this.Variation == null && ParameterWasBound(nameof(this.Variation)))
            {
                WriteWarning("You are passing $null as a value for parameter Variation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchEvidently.Model.CreateFeatureRequest();
            
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Project != null)
            {
                request.Project = cmdletContext.Project;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Variation != null)
            {
                request.Variations = cmdletContext.Variation;
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
        
        private Amazon.CloudWatchEvidently.Model.CreateFeatureResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.CreateFeatureRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "CreateFeature");
            try
            {
                #if DESKTOP
                return client.CreateFeature(request);
                #elif CORECLR
                return client.CreateFeatureAsync(request).GetAwaiter().GetResult();
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
            public System.String DefaultVariation { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> EntityOverride { get; set; }
            public Amazon.CloudWatchEvidently.FeatureEvaluationStrategy EvaluationStrategy { get; set; }
            public System.String Name { get; set; }
            public System.String Project { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.CloudWatchEvidently.Model.VariationConfig> Variation { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.CreateFeatureResponse, NewCWEVDFeatureCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Feature;
        }
        
    }
}
