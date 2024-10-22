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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Updates an Amazon Pinpoint configuration for a recommender model.
    /// </summary>
    [Cmdlet("Update", "PINRecommenderConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.RecommenderConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateRecommenderConfiguration API operation.", Operation = new[] {"UpdateRecommenderConfiguration"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateRecommenderConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.RecommenderConfigurationResponse or Amazon.Pinpoint.Model.UpdateRecommenderConfigurationResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.RecommenderConfigurationResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateRecommenderConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINRecommenderConfigurationCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter UpdateRecommenderConfiguration_Attribute
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs that defines 1-10 custom endpoint or user attributes, depending
        /// on the value for the RecommendationProviderIdType property. Each of these attributes
        /// temporarily stores a recommended item that's retrieved from the recommender model
        /// and sent to an AWS Lambda function for additional processing. Each attribute can be
        /// used as a message variable in a message template.</para><para>In the map, the key is the name of a custom attribute and the value is a custom display
        /// name for that attribute. The display name appears in the <b>Attribute finder</b> of
        /// the template editor on the Amazon Pinpoint console. The following restrictions apply
        /// to these names:</para><ul><li><para>An attribute name must start with a letter or number and it can contain up to 50 characters.
        /// The characters can be letters, numbers, underscores (_), or hyphens (-). Attribute
        /// names are case sensitive and must be unique.</para></li><li><para>An attribute display name must start with a letter or number and it can contain up
        /// to 25 characters. The characters can be letters, numbers, spaces, underscores (_),
        /// or hyphens (-).</para></li></ul><para>This object is required if the configuration invokes an AWS Lambda function (RecommendationTransformerUri)
        /// to process recommendation data. Otherwise, don't include this object in your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateRecommenderConfiguration_Attributes")]
        public System.Collections.Hashtable UpdateRecommenderConfiguration_Attribute { get; set; }
        #endregion
        
        #region Parameter UpdateRecommenderConfiguration_Description
        /// <summary>
        /// <para>
        /// <para>A custom description of the configuration for the recommender model. The description
        /// can contain up to 128 characters. The characters can be letters, numbers, spaces,
        /// or the following symbols: _ ; () , ‐.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateRecommenderConfiguration_Description { get; set; }
        #endregion
        
        #region Parameter UpdateRecommenderConfiguration_Name
        /// <summary>
        /// <para>
        /// <para>A custom name of the configuration for the recommender model. The name must start
        /// with a letter or number and it can contain up to 128 characters. The characters can
        /// be letters, numbers, spaces, underscores (_), or hyphens (-).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateRecommenderConfiguration_Name { get; set; }
        #endregion
        
        #region Parameter UpdateRecommenderConfiguration_RecommendationProviderIdType
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Pinpoint ID to associate with unique user IDs in the recommender
        /// model. This value enables the model to use attribute and event data that’s specific
        /// to a particular endpoint or user in an Amazon Pinpoint application. Valid values are:</para><ul><li><para>PINPOINT_ENDPOINT_ID - Associate each user in the model with a particular endpoint
        /// in Amazon Pinpoint. The data is correlated based on endpoint IDs in Amazon Pinpoint.
        /// This is the default value.</para></li><li><para>PINPOINT_USER_ID - Associate each user in the model with a particular user and endpoint
        /// in Amazon Pinpoint. The data is correlated based on user IDs in Amazon Pinpoint. If
        /// you specify this value, an endpoint definition in Amazon Pinpoint has to specify both
        /// a user ID (UserId) and an endpoint ID. Otherwise, messages won’t be sent to the user's
        /// endpoint.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateRecommenderConfiguration_RecommendationProviderIdType { get; set; }
        #endregion
        
        #region Parameter UpdateRecommenderConfiguration_RecommendationProviderRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Access Management (IAM) role
        /// that authorizes Amazon Pinpoint to retrieve recommendation data from the recommender
        /// model.</para>
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
        public System.String UpdateRecommenderConfiguration_RecommendationProviderRoleArn { get; set; }
        #endregion
        
        #region Parameter UpdateRecommenderConfiguration_RecommendationProviderUri
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the recommender model to retrieve recommendation
        /// data from. This value must match the ARN of an Amazon Personalize campaign.</para>
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
        public System.String UpdateRecommenderConfiguration_RecommendationProviderUri { get; set; }
        #endregion
        
        #region Parameter UpdateRecommenderConfiguration_RecommendationsDisplayName
        /// <summary>
        /// <para>
        /// <para>A custom display name for the standard endpoint or user attribute (RecommendationItems)
        /// that temporarily stores recommended items for each endpoint or user, depending on
        /// the value for the RecommendationProviderIdType property. This value is required if
        /// the configuration doesn't invoke an AWS Lambda function (RecommendationTransformerUri)
        /// to perform additional processing of recommendation data.</para><para>This name appears in the <b>Attribute finder</b> of the template editor on the Amazon
        /// Pinpoint console. The name can contain up to 25 characters. The characters can be
        /// letters, numbers, spaces, underscores (_), or hyphens (-). These restrictions don't
        /// apply to attribute values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateRecommenderConfiguration_RecommendationsDisplayName { get; set; }
        #endregion
        
        #region Parameter UpdateRecommenderConfiguration_RecommendationsPerMessage
        /// <summary>
        /// <para>
        /// <para>The number of recommended items to retrieve from the model for each endpoint or user,
        /// depending on the value for the RecommendationProviderIdType property. This number
        /// determines how many recommended items are available for use in message variables.
        /// The minimum value is 1. The maximum value is 5. The default value is 5.</para><para>To use multiple recommended items and custom attributes with message variables, you
        /// have to use an AWS Lambda function (RecommendationTransformerUri) to perform additional
        /// processing of recommendation data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UpdateRecommenderConfiguration_RecommendationsPerMessage { get; set; }
        #endregion
        
        #region Parameter UpdateRecommenderConfiguration_RecommendationTransformerUri
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the AWS Lambda function to invoke for additional
        /// processing of recommendation data that's retrieved from the recommender model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateRecommenderConfiguration_RecommendationTransformerUri { get; set; }
        #endregion
        
        #region Parameter RecommenderId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the recommender model configuration. This identifier is
        /// displayed as the <b>Recommender ID</b> on the Amazon Pinpoint console.</para>
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
        public System.String RecommenderId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommenderConfigurationResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateRecommenderConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateRecommenderConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommenderConfigurationResponse";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecommenderId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINRecommenderConfiguration (UpdateRecommenderConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateRecommenderConfigurationResponse, UpdatePINRecommenderConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RecommenderId = this.RecommenderId;
            #if MODULAR
            if (this.RecommenderId == null && ParameterWasBound(nameof(this.RecommenderId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommenderId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UpdateRecommenderConfiguration_Attribute != null)
            {
                context.UpdateRecommenderConfiguration_Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.UpdateRecommenderConfiguration_Attribute.Keys)
                {
                    context.UpdateRecommenderConfiguration_Attribute.Add((String)hashKey, (System.String)(this.UpdateRecommenderConfiguration_Attribute[hashKey]));
                }
            }
            context.UpdateRecommenderConfiguration_Description = this.UpdateRecommenderConfiguration_Description;
            context.UpdateRecommenderConfiguration_Name = this.UpdateRecommenderConfiguration_Name;
            context.UpdateRecommenderConfiguration_RecommendationProviderIdType = this.UpdateRecommenderConfiguration_RecommendationProviderIdType;
            context.UpdateRecommenderConfiguration_RecommendationProviderRoleArn = this.UpdateRecommenderConfiguration_RecommendationProviderRoleArn;
            #if MODULAR
            if (this.UpdateRecommenderConfiguration_RecommendationProviderRoleArn == null && ParameterWasBound(nameof(this.UpdateRecommenderConfiguration_RecommendationProviderRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateRecommenderConfiguration_RecommendationProviderRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateRecommenderConfiguration_RecommendationProviderUri = this.UpdateRecommenderConfiguration_RecommendationProviderUri;
            #if MODULAR
            if (this.UpdateRecommenderConfiguration_RecommendationProviderUri == null && ParameterWasBound(nameof(this.UpdateRecommenderConfiguration_RecommendationProviderUri)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateRecommenderConfiguration_RecommendationProviderUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateRecommenderConfiguration_RecommendationsDisplayName = this.UpdateRecommenderConfiguration_RecommendationsDisplayName;
            context.UpdateRecommenderConfiguration_RecommendationsPerMessage = this.UpdateRecommenderConfiguration_RecommendationsPerMessage;
            context.UpdateRecommenderConfiguration_RecommendationTransformerUri = this.UpdateRecommenderConfiguration_RecommendationTransformerUri;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateRecommenderConfigurationRequest();
            
            if (cmdletContext.RecommenderId != null)
            {
                request.RecommenderId = cmdletContext.RecommenderId;
            }
            
             // populate UpdateRecommenderConfiguration
            var requestUpdateRecommenderConfigurationIsNull = true;
            request.UpdateRecommenderConfiguration = new Amazon.Pinpoint.Model.UpdateRecommenderConfiguration();
            Dictionary<System.String, System.String> requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Attribute = null;
            if (cmdletContext.UpdateRecommenderConfiguration_Attribute != null)
            {
                requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Attribute = cmdletContext.UpdateRecommenderConfiguration_Attribute;
            }
            if (requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Attribute != null)
            {
                request.UpdateRecommenderConfiguration.Attributes = requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Attribute;
                requestUpdateRecommenderConfigurationIsNull = false;
            }
            System.String requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Description = null;
            if (cmdletContext.UpdateRecommenderConfiguration_Description != null)
            {
                requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Description = cmdletContext.UpdateRecommenderConfiguration_Description;
            }
            if (requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Description != null)
            {
                request.UpdateRecommenderConfiguration.Description = requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Description;
                requestUpdateRecommenderConfigurationIsNull = false;
            }
            System.String requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Name = null;
            if (cmdletContext.UpdateRecommenderConfiguration_Name != null)
            {
                requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Name = cmdletContext.UpdateRecommenderConfiguration_Name;
            }
            if (requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Name != null)
            {
                request.UpdateRecommenderConfiguration.Name = requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_Name;
                requestUpdateRecommenderConfigurationIsNull = false;
            }
            System.String requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderIdType = null;
            if (cmdletContext.UpdateRecommenderConfiguration_RecommendationProviderIdType != null)
            {
                requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderIdType = cmdletContext.UpdateRecommenderConfiguration_RecommendationProviderIdType;
            }
            if (requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderIdType != null)
            {
                request.UpdateRecommenderConfiguration.RecommendationProviderIdType = requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderIdType;
                requestUpdateRecommenderConfigurationIsNull = false;
            }
            System.String requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderRoleArn = null;
            if (cmdletContext.UpdateRecommenderConfiguration_RecommendationProviderRoleArn != null)
            {
                requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderRoleArn = cmdletContext.UpdateRecommenderConfiguration_RecommendationProviderRoleArn;
            }
            if (requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderRoleArn != null)
            {
                request.UpdateRecommenderConfiguration.RecommendationProviderRoleArn = requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderRoleArn;
                requestUpdateRecommenderConfigurationIsNull = false;
            }
            System.String requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderUri = null;
            if (cmdletContext.UpdateRecommenderConfiguration_RecommendationProviderUri != null)
            {
                requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderUri = cmdletContext.UpdateRecommenderConfiguration_RecommendationProviderUri;
            }
            if (requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderUri != null)
            {
                request.UpdateRecommenderConfiguration.RecommendationProviderUri = requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationProviderUri;
                requestUpdateRecommenderConfigurationIsNull = false;
            }
            System.String requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationsDisplayName = null;
            if (cmdletContext.UpdateRecommenderConfiguration_RecommendationsDisplayName != null)
            {
                requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationsDisplayName = cmdletContext.UpdateRecommenderConfiguration_RecommendationsDisplayName;
            }
            if (requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationsDisplayName != null)
            {
                request.UpdateRecommenderConfiguration.RecommendationsDisplayName = requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationsDisplayName;
                requestUpdateRecommenderConfigurationIsNull = false;
            }
            System.Int32? requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationsPerMessage = null;
            if (cmdletContext.UpdateRecommenderConfiguration_RecommendationsPerMessage != null)
            {
                requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationsPerMessage = cmdletContext.UpdateRecommenderConfiguration_RecommendationsPerMessage.Value;
            }
            if (requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationsPerMessage != null)
            {
                request.UpdateRecommenderConfiguration.RecommendationsPerMessage = requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationsPerMessage.Value;
                requestUpdateRecommenderConfigurationIsNull = false;
            }
            System.String requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationTransformerUri = null;
            if (cmdletContext.UpdateRecommenderConfiguration_RecommendationTransformerUri != null)
            {
                requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationTransformerUri = cmdletContext.UpdateRecommenderConfiguration_RecommendationTransformerUri;
            }
            if (requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationTransformerUri != null)
            {
                request.UpdateRecommenderConfiguration.RecommendationTransformerUri = requestUpdateRecommenderConfiguration_updateRecommenderConfiguration_RecommendationTransformerUri;
                requestUpdateRecommenderConfigurationIsNull = false;
            }
             // determine if request.UpdateRecommenderConfiguration should be set to null
            if (requestUpdateRecommenderConfigurationIsNull)
            {
                request.UpdateRecommenderConfiguration = null;
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
        
        private Amazon.Pinpoint.Model.UpdateRecommenderConfigurationResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateRecommenderConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateRecommenderConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateRecommenderConfiguration(request);
                #elif CORECLR
                return client.UpdateRecommenderConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String RecommenderId { get; set; }
            public Dictionary<System.String, System.String> UpdateRecommenderConfiguration_Attribute { get; set; }
            public System.String UpdateRecommenderConfiguration_Description { get; set; }
            public System.String UpdateRecommenderConfiguration_Name { get; set; }
            public System.String UpdateRecommenderConfiguration_RecommendationProviderIdType { get; set; }
            public System.String UpdateRecommenderConfiguration_RecommendationProviderRoleArn { get; set; }
            public System.String UpdateRecommenderConfiguration_RecommendationProviderUri { get; set; }
            public System.String UpdateRecommenderConfiguration_RecommendationsDisplayName { get; set; }
            public System.Int32? UpdateRecommenderConfiguration_RecommendationsPerMessage { get; set; }
            public System.String UpdateRecommenderConfiguration_RecommendationTransformerUri { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateRecommenderConfigurationResponse, UpdatePINRecommenderConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommenderConfigurationResponse;
        }
        
    }
}
