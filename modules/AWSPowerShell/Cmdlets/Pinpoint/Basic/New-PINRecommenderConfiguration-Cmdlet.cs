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
    /// Creates an Amazon Pinpoint configuration for a recommender model.
    /// </summary>
    [Cmdlet("New", "PINRecommenderConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.RecommenderConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateRecommenderConfiguration API operation.", Operation = new[] {"CreateRecommenderConfiguration"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.CreateRecommenderConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.RecommenderConfigurationResponse or Amazon.Pinpoint.Model.CreateRecommenderConfigurationResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.RecommenderConfigurationResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateRecommenderConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINRecommenderConfigurationCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter CreateRecommenderConfiguration_Attribute
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs that defines 1-10 custom endpoint or user attributes, depending
        /// on the value for the RecommenderUserIdType property. Each of these attributes temporarily
        /// stores a recommended item that's retrieved from the recommender model and sent to
        /// an AWS Lambda function for additional processing. Each attribute can be used as a
        /// message variable in a message template.</para><para>In the map, the key is the name of a custom attribute and the value is a custom display
        /// name for that attribute. The display name appears in the <b>Attribute finder</b> pane
        /// of the template editor on the Amazon Pinpoint console. The following restrictions
        /// apply to these names:</para><ul><li><para>An attribute name must start with a letter or number and it can contain up to 50 characters.
        /// The characters can be letters, numbers, underscores (_), or hyphens (-). Attribute
        /// names are case sensitive and must be unique.</para></li><li><para>An attribute display name must start with a letter or number and it can contain up
        /// to 25 characters. The characters can be letters, numbers, spaces, underscores (_),
        /// or hyphens (-).</para></li></ul><para>This object is required if the configuration invokes an AWS Lambda function (LambdaFunctionArn)
        /// to process recommendation data. Otherwise, don't include this object in your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CreateRecommenderConfiguration_Attributes")]
        public System.Collections.Hashtable CreateRecommenderConfiguration_Attribute { get; set; }
        #endregion
        
        #region Parameter CreateRecommenderConfiguration_Description
        /// <summary>
        /// <para>
        /// <para>A custom description of the configuration for the recommender model. The description
        /// can contain up to 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreateRecommenderConfiguration_Description { get; set; }
        #endregion
        
        #region Parameter CreateRecommenderConfiguration_Name
        /// <summary>
        /// <para>
        /// <para>A custom name of the configuration for the recommender model. The name must start
        /// with a letter or number and it can contain up to 128 characters. The characters can
        /// be letters, numbers, spaces, underscores (_), or hyphens (-).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreateRecommenderConfiguration_Name { get; set; }
        #endregion
        
        #region Parameter CreateRecommenderConfiguration_RecommendationProviderIdType
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Pinpoint ID to associate with unique user IDs in the recommender
        /// model. This value enables the model to use attribute and event data that’s specific
        /// to a particular endpoint or user in an Amazon Pinpoint application. Valid values are:</para><ul><li><para>PINPOINT_ENDPOINT_ID - Associate each user in the model with a particular endpoint
        /// in Amazon Pinpoint. The data is correlated based on endpoint IDs in Amazon Pinpoint.
        /// This is the default value.</para></li><li><para>PINPOINT_USER_ID - Associate each user in the model with a particular user and endpoint
        /// in Amazon Pinpoint. The data is correlated based on user IDs in Amazon Pinpoint. If
        /// you specify this value, an endpoint definition in Amazon Pinpoint has to specify a
        /// both a user ID (UserId) and an endpoint ID. Otherwise, messages won’t be sent to the
        /// user's endpoint.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreateRecommenderConfiguration_RecommendationProviderIdType { get; set; }
        #endregion
        
        #region Parameter CreateRecommenderConfiguration_RecommendationProviderRoleArn
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
        public System.String CreateRecommenderConfiguration_RecommendationProviderRoleArn { get; set; }
        #endregion
        
        #region Parameter CreateRecommenderConfiguration_RecommendationProviderUri
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the recommender model to retrieve recommendation
        /// data from. This value must match the ARN of an Amazon Personalize campaign.</para>
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
        public System.String CreateRecommenderConfiguration_RecommendationProviderUri { get; set; }
        #endregion
        
        #region Parameter CreateRecommenderConfiguration_RecommendationsDisplayName
        /// <summary>
        /// <para>
        /// <para>A custom display name for the standard endpoint or user attribute (RecommendationItems)
        /// that temporarily stores a recommended item for each endpoint or user, depending on
        /// the value for the RecommenderUserIdType property. This value is required if the configuration
        /// doesn't invoke an AWS Lambda function (LambdaFunctionArn) to perform additional processing
        /// of recommendation data.</para><para>This name appears in the <b>Attribute finder</b> pane of the template editor on the
        /// Amazon Pinpoint console. The name can contain up to 25 characters. The characters
        /// can be letters, numbers, spaces, underscores (_), or hyphens (-). These restrictions
        /// don't apply to attribute values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreateRecommenderConfiguration_RecommendationsDisplayName { get; set; }
        #endregion
        
        #region Parameter CreateRecommenderConfiguration_RecommendationsPerMessage
        /// <summary>
        /// <para>
        /// <para>The number of recommended items to retrieve from the model for each endpoint or user,
        /// depending on the value for the RecommenderUserIdType property. This number determines
        /// how many recommended attributes are available for use as message variables in message
        /// templates. The minimum value is 1. The maximum value is 5. The default value is 5.</para><para>To use multiple recommended items and custom attributes with message variables, you
        /// have to use an AWS Lambda function (LambdaFunctionArn) to perform additional processing
        /// of recommendation data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CreateRecommenderConfiguration_RecommendationsPerMessage { get; set; }
        #endregion
        
        #region Parameter CreateRecommenderConfiguration_RecommendationTransformerUri
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the AWS Lambda function to invoke for additional
        /// processing of recommendation data that's retrieved from the recommender model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreateRecommenderConfiguration_RecommendationTransformerUri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommenderConfigurationResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.CreateRecommenderConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.CreateRecommenderConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommenderConfigurationResponse";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CreateRecommenderConfiguration_RecommendationProviderUri parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CreateRecommenderConfiguration_RecommendationProviderUri' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CreateRecommenderConfiguration_RecommendationProviderUri' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CreateRecommenderConfiguration_RecommendationProviderUri), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINRecommenderConfiguration (CreateRecommenderConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.CreateRecommenderConfigurationResponse, NewPINRecommenderConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CreateRecommenderConfiguration_RecommendationProviderUri;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CreateRecommenderConfiguration_Attribute != null)
            {
                context.CreateRecommenderConfiguration_Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CreateRecommenderConfiguration_Attribute.Keys)
                {
                    context.CreateRecommenderConfiguration_Attribute.Add((String)hashKey, (String)(this.CreateRecommenderConfiguration_Attribute[hashKey]));
                }
            }
            context.CreateRecommenderConfiguration_Description = this.CreateRecommenderConfiguration_Description;
            context.CreateRecommenderConfiguration_Name = this.CreateRecommenderConfiguration_Name;
            context.CreateRecommenderConfiguration_RecommendationProviderIdType = this.CreateRecommenderConfiguration_RecommendationProviderIdType;
            context.CreateRecommenderConfiguration_RecommendationProviderRoleArn = this.CreateRecommenderConfiguration_RecommendationProviderRoleArn;
            #if MODULAR
            if (this.CreateRecommenderConfiguration_RecommendationProviderRoleArn == null && ParameterWasBound(nameof(this.CreateRecommenderConfiguration_RecommendationProviderRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CreateRecommenderConfiguration_RecommendationProviderRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CreateRecommenderConfiguration_RecommendationProviderUri = this.CreateRecommenderConfiguration_RecommendationProviderUri;
            #if MODULAR
            if (this.CreateRecommenderConfiguration_RecommendationProviderUri == null && ParameterWasBound(nameof(this.CreateRecommenderConfiguration_RecommendationProviderUri)))
            {
                WriteWarning("You are passing $null as a value for parameter CreateRecommenderConfiguration_RecommendationProviderUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CreateRecommenderConfiguration_RecommendationsDisplayName = this.CreateRecommenderConfiguration_RecommendationsDisplayName;
            context.CreateRecommenderConfiguration_RecommendationsPerMessage = this.CreateRecommenderConfiguration_RecommendationsPerMessage;
            context.CreateRecommenderConfiguration_RecommendationTransformerUri = this.CreateRecommenderConfiguration_RecommendationTransformerUri;
            
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
            var request = new Amazon.Pinpoint.Model.CreateRecommenderConfigurationRequest();
            
            
             // populate CreateRecommenderConfiguration
            var requestCreateRecommenderConfigurationIsNull = true;
            request.CreateRecommenderConfiguration = new Amazon.Pinpoint.Model.CreateRecommenderConfiguration();
            Dictionary<System.String, System.String> requestCreateRecommenderConfiguration_createRecommenderConfiguration_Attribute = null;
            if (cmdletContext.CreateRecommenderConfiguration_Attribute != null)
            {
                requestCreateRecommenderConfiguration_createRecommenderConfiguration_Attribute = cmdletContext.CreateRecommenderConfiguration_Attribute;
            }
            if (requestCreateRecommenderConfiguration_createRecommenderConfiguration_Attribute != null)
            {
                request.CreateRecommenderConfiguration.Attributes = requestCreateRecommenderConfiguration_createRecommenderConfiguration_Attribute;
                requestCreateRecommenderConfigurationIsNull = false;
            }
            System.String requestCreateRecommenderConfiguration_createRecommenderConfiguration_Description = null;
            if (cmdletContext.CreateRecommenderConfiguration_Description != null)
            {
                requestCreateRecommenderConfiguration_createRecommenderConfiguration_Description = cmdletContext.CreateRecommenderConfiguration_Description;
            }
            if (requestCreateRecommenderConfiguration_createRecommenderConfiguration_Description != null)
            {
                request.CreateRecommenderConfiguration.Description = requestCreateRecommenderConfiguration_createRecommenderConfiguration_Description;
                requestCreateRecommenderConfigurationIsNull = false;
            }
            System.String requestCreateRecommenderConfiguration_createRecommenderConfiguration_Name = null;
            if (cmdletContext.CreateRecommenderConfiguration_Name != null)
            {
                requestCreateRecommenderConfiguration_createRecommenderConfiguration_Name = cmdletContext.CreateRecommenderConfiguration_Name;
            }
            if (requestCreateRecommenderConfiguration_createRecommenderConfiguration_Name != null)
            {
                request.CreateRecommenderConfiguration.Name = requestCreateRecommenderConfiguration_createRecommenderConfiguration_Name;
                requestCreateRecommenderConfigurationIsNull = false;
            }
            System.String requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderIdType = null;
            if (cmdletContext.CreateRecommenderConfiguration_RecommendationProviderIdType != null)
            {
                requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderIdType = cmdletContext.CreateRecommenderConfiguration_RecommendationProviderIdType;
            }
            if (requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderIdType != null)
            {
                request.CreateRecommenderConfiguration.RecommendationProviderIdType = requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderIdType;
                requestCreateRecommenderConfigurationIsNull = false;
            }
            System.String requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderRoleArn = null;
            if (cmdletContext.CreateRecommenderConfiguration_RecommendationProviderRoleArn != null)
            {
                requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderRoleArn = cmdletContext.CreateRecommenderConfiguration_RecommendationProviderRoleArn;
            }
            if (requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderRoleArn != null)
            {
                request.CreateRecommenderConfiguration.RecommendationProviderRoleArn = requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderRoleArn;
                requestCreateRecommenderConfigurationIsNull = false;
            }
            System.String requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderUri = null;
            if (cmdletContext.CreateRecommenderConfiguration_RecommendationProviderUri != null)
            {
                requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderUri = cmdletContext.CreateRecommenderConfiguration_RecommendationProviderUri;
            }
            if (requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderUri != null)
            {
                request.CreateRecommenderConfiguration.RecommendationProviderUri = requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationProviderUri;
                requestCreateRecommenderConfigurationIsNull = false;
            }
            System.String requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationsDisplayName = null;
            if (cmdletContext.CreateRecommenderConfiguration_RecommendationsDisplayName != null)
            {
                requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationsDisplayName = cmdletContext.CreateRecommenderConfiguration_RecommendationsDisplayName;
            }
            if (requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationsDisplayName != null)
            {
                request.CreateRecommenderConfiguration.RecommendationsDisplayName = requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationsDisplayName;
                requestCreateRecommenderConfigurationIsNull = false;
            }
            System.Int32? requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationsPerMessage = null;
            if (cmdletContext.CreateRecommenderConfiguration_RecommendationsPerMessage != null)
            {
                requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationsPerMessage = cmdletContext.CreateRecommenderConfiguration_RecommendationsPerMessage.Value;
            }
            if (requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationsPerMessage != null)
            {
                request.CreateRecommenderConfiguration.RecommendationsPerMessage = requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationsPerMessage.Value;
                requestCreateRecommenderConfigurationIsNull = false;
            }
            System.String requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationTransformerUri = null;
            if (cmdletContext.CreateRecommenderConfiguration_RecommendationTransformerUri != null)
            {
                requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationTransformerUri = cmdletContext.CreateRecommenderConfiguration_RecommendationTransformerUri;
            }
            if (requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationTransformerUri != null)
            {
                request.CreateRecommenderConfiguration.RecommendationTransformerUri = requestCreateRecommenderConfiguration_createRecommenderConfiguration_RecommendationTransformerUri;
                requestCreateRecommenderConfigurationIsNull = false;
            }
             // determine if request.CreateRecommenderConfiguration should be set to null
            if (requestCreateRecommenderConfigurationIsNull)
            {
                request.CreateRecommenderConfiguration = null;
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
        
        private Amazon.Pinpoint.Model.CreateRecommenderConfigurationResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateRecommenderConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateRecommenderConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateRecommenderConfiguration(request);
                #elif CORECLR
                return client.CreateRecommenderConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> CreateRecommenderConfiguration_Attribute { get; set; }
            public System.String CreateRecommenderConfiguration_Description { get; set; }
            public System.String CreateRecommenderConfiguration_Name { get; set; }
            public System.String CreateRecommenderConfiguration_RecommendationProviderIdType { get; set; }
            public System.String CreateRecommenderConfiguration_RecommendationProviderRoleArn { get; set; }
            public System.String CreateRecommenderConfiguration_RecommendationProviderUri { get; set; }
            public System.String CreateRecommenderConfiguration_RecommendationsDisplayName { get; set; }
            public System.Int32? CreateRecommenderConfiguration_RecommendationsPerMessage { get; set; }
            public System.String CreateRecommenderConfiguration_RecommendationTransformerUri { get; set; }
            public System.Func<Amazon.Pinpoint.Model.CreateRecommenderConfigurationResponse, NewPINRecommenderConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommenderConfigurationResponse;
        }
        
    }
}
