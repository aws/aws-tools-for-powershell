/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    
    /// </summary>
    [Cmdlet("New", "AGDocumentationPart", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateDocumentationPartResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateDocumentationPart API operation.", Operation = new[] {"CreateDocumentationPart"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateDocumentationPartResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.CreateDocumentationPartResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAGDocumentationPartCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter Location_Method
        /// <summary>
        /// <para>
        /// <para>The HTTP verb of a method. It is a valid field for the API entity types of <code>METHOD</code>,
        /// <code>PATH_PARAMETER</code>, <code>QUERY_PARAMETER</code>, <code>REQUEST_HEADER</code>,
        /// <code>REQUEST_BODY</code>, <code>RESPONSE</code>, <code>RESPONSE_HEADER</code>, and
        /// <code>RESPONSE_BODY</code>. The default value is <code>*</code> for any method. When
        /// an applicable child entity inherits the content of an entity of the same type with
        /// more general specifications of the other <code>location</code> attributes, the child
        /// entity's <code>method</code> attribute must match that of the parent entity exactly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Location_Method { get; set; }
        #endregion
        
        #region Parameter Location_Name
        /// <summary>
        /// <para>
        /// <para>The name of the targeted API entity. It is a valid and required field for the API
        /// entity types of <code>AUTHORIZER</code>, <code>MODEL</code>, <code>PATH_PARAMETER</code>,
        /// <code>QUERY_PARAMETER</code>, <code>REQUEST_HEADER</code>, <code>REQUEST_BODY</code>
        /// and <code>RESPONSE_HEADER</code>. It is an invalid field for any other entity type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Location_Name { get; set; }
        #endregion
        
        #region Parameter Location_Path
        /// <summary>
        /// <para>
        /// <para>The URL path of the target. It is a valid field for the API entity types of <code>RESOURCE</code>,
        /// <code>METHOD</code>, <code>PATH_PARAMETER</code>, <code>QUERY_PARAMETER</code>, <code>REQUEST_HEADER</code>,
        /// <code>REQUEST_BODY</code>, <code>RESPONSE</code>, <code>RESPONSE_HEADER</code>, and
        /// <code>RESPONSE_BODY</code>. The default value is <code>/</code> for the root resource.
        /// When an applicable child entity inherits the content of another entity of the same
        /// type with more general specifications of the other <code>location</code> attributes,
        /// the child entity's <code>path</code> attribute must match that of the parent entity
        /// as a prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Location_Path { get; set; }
        #endregion
        
        #region Parameter Property
        /// <summary>
        /// <para>
        /// <para>[Required] The new documentation content map of the targeted API entity. Enclosed
        /// key-value pairs are API-specific, but only Swagger-compliant key-value pairs can be
        /// exported and, hence, published.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Properties")]
        public System.String Property { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>[Required] The string identifier of the associated <a>RestApi</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter Location_StatusCode
        /// <summary>
        /// <para>
        /// <para>The HTTP status code of a response. It is a valid field for the API entity types of
        /// <code>RESPONSE</code>, <code>RESPONSE_HEADER</code>, and <code>RESPONSE_BODY</code>.
        /// The default value is <code>*</code> for any status code. When an applicable child
        /// entity inherits the content of an entity of the same type with more general specifications
        /// of the other <code>location</code> attributes, the child entity's <code>statusCode</code>
        /// attribute must match that of the parent entity exactly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Location_StatusCode { get; set; }
        #endregion
        
        #region Parameter Location_Type
        /// <summary>
        /// <para>
        /// <para>The type of API entity to which the documentation content applies. It is a valid and
        /// required field for API entity types of <code>API</code>, <code>AUTHORIZER</code>,
        /// <code>MODEL</code>, <code>RESOURCE</code>, <code>METHOD</code>, <code>PATH_PARAMETER</code>,
        /// <code>QUERY_PARAMETER</code>, <code>REQUEST_HEADER</code>, <code>REQUEST_BODY</code>,
        /// <code>RESPONSE</code>, <code>RESPONSE_HEADER</code>, and <code>RESPONSE_BODY</code>.
        /// Content inheritance does not apply to any entity of the <code>API</code>, <code>AUTHORIZER</code>,
        /// <code>METHOD</code>, <code>MODEL</code>, <code>REQUEST_BODY</code>, or <code>RESOURCE</code>
        /// type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.DocumentationPartType")]
        public Amazon.APIGateway.DocumentationPartType Location_Type { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RestApiId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGDocumentationPart (CreateDocumentationPart)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Location_Method = this.Location_Method;
            context.Location_Name = this.Location_Name;
            context.Location_Path = this.Location_Path;
            context.Location_StatusCode = this.Location_StatusCode;
            context.Location_Type = this.Location_Type;
            context.Properties = this.Property;
            context.RestApiId = this.RestApiId;
            
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
            var request = new Amazon.APIGateway.Model.CreateDocumentationPartRequest();
            
            
             // populate Location
            bool requestLocationIsNull = true;
            request.Location = new Amazon.APIGateway.Model.DocumentationPartLocation();
            System.String requestLocation_location_Method = null;
            if (cmdletContext.Location_Method != null)
            {
                requestLocation_location_Method = cmdletContext.Location_Method;
            }
            if (requestLocation_location_Method != null)
            {
                request.Location.Method = requestLocation_location_Method;
                requestLocationIsNull = false;
            }
            System.String requestLocation_location_Name = null;
            if (cmdletContext.Location_Name != null)
            {
                requestLocation_location_Name = cmdletContext.Location_Name;
            }
            if (requestLocation_location_Name != null)
            {
                request.Location.Name = requestLocation_location_Name;
                requestLocationIsNull = false;
            }
            System.String requestLocation_location_Path = null;
            if (cmdletContext.Location_Path != null)
            {
                requestLocation_location_Path = cmdletContext.Location_Path;
            }
            if (requestLocation_location_Path != null)
            {
                request.Location.Path = requestLocation_location_Path;
                requestLocationIsNull = false;
            }
            System.String requestLocation_location_StatusCode = null;
            if (cmdletContext.Location_StatusCode != null)
            {
                requestLocation_location_StatusCode = cmdletContext.Location_StatusCode;
            }
            if (requestLocation_location_StatusCode != null)
            {
                request.Location.StatusCode = requestLocation_location_StatusCode;
                requestLocationIsNull = false;
            }
            Amazon.APIGateway.DocumentationPartType requestLocation_location_Type = null;
            if (cmdletContext.Location_Type != null)
            {
                requestLocation_location_Type = cmdletContext.Location_Type;
            }
            if (requestLocation_location_Type != null)
            {
                request.Location.Type = requestLocation_location_Type;
                requestLocationIsNull = false;
            }
             // determine if request.Location should be set to null
            if (requestLocationIsNull)
            {
                request.Location = null;
            }
            if (cmdletContext.Properties != null)
            {
                request.Properties = cmdletContext.Properties;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.APIGateway.Model.CreateDocumentationPartResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateDocumentationPartRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateDocumentationPart");
            try
            {
                #if DESKTOP
                return client.CreateDocumentationPart(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDocumentationPartAsync(request);
                return task.Result;
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
            public System.String Location_Method { get; set; }
            public System.String Location_Name { get; set; }
            public System.String Location_Path { get; set; }
            public System.String Location_StatusCode { get; set; }
            public Amazon.APIGateway.DocumentationPartType Location_Type { get; set; }
            public System.String Properties { get; set; }
            public System.String RestApiId { get; set; }
        }
        
    }
}
