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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Creates a documentation part.
    /// </summary>
    [Cmdlet("New", "AGDocumentationPart", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateDocumentationPartResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateDocumentationPart API operation.", Operation = new[] {"CreateDocumentationPart"}, SelectReturnType = typeof(Amazon.APIGateway.Model.CreateDocumentationPartResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateDocumentationPartResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.CreateDocumentationPartResponse object containing multiple properties."
    )]
    public partial class NewAGDocumentationPartCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Location_Method
        /// <summary>
        /// <para>
        /// <para>The HTTP verb of a method. It is a valid field for the API entity types of <c>METHOD</c>,
        /// <c>PATH_PARAMETER</c>, <c>QUERY_PARAMETER</c>, <c>REQUEST_HEADER</c>, <c>REQUEST_BODY</c>,
        /// <c>RESPONSE</c>, <c>RESPONSE_HEADER</c>, and <c>RESPONSE_BODY</c>. The default value
        /// is <c>*</c> for any method. When an applicable child entity inherits the content of
        /// an entity of the same type with more general specifications of the other <c>location</c>
        /// attributes, the child entity's <c>method</c> attribute must match that of the parent
        /// entity exactly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_Method { get; set; }
        #endregion
        
        #region Parameter Location_Name
        /// <summary>
        /// <para>
        /// <para>The name of the targeted API entity. It is a valid and required field for the API
        /// entity types of <c>AUTHORIZER</c>, <c>MODEL</c>, <c>PATH_PARAMETER</c>, <c>QUERY_PARAMETER</c>,
        /// <c>REQUEST_HEADER</c>, <c>REQUEST_BODY</c> and <c>RESPONSE_HEADER</c>. It is an invalid
        /// field for any other entity type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_Name { get; set; }
        #endregion
        
        #region Parameter Location_Path
        /// <summary>
        /// <para>
        /// <para>The URL path of the target. It is a valid field for the API entity types of <c>RESOURCE</c>,
        /// <c>METHOD</c>, <c>PATH_PARAMETER</c>, <c>QUERY_PARAMETER</c>, <c>REQUEST_HEADER</c>,
        /// <c>REQUEST_BODY</c>, <c>RESPONSE</c>, <c>RESPONSE_HEADER</c>, and <c>RESPONSE_BODY</c>.
        /// The default value is <c>/</c> for the root resource. When an applicable child entity
        /// inherits the content of another entity of the same type with more general specifications
        /// of the other <c>location</c> attributes, the child entity's <c>path</c> attribute
        /// must match that of the parent entity as a prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_Path { get; set; }
        #endregion
        
        #region Parameter Property
        /// <summary>
        /// <para>
        /// <para>The new documentation content map of the targeted API entity. Enclosed key-value pairs
        /// are API-specific, but only OpenAPI-compliant key-value pairs can be exported and,
        /// hence, published.</para>
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
        [Alias("Properties")]
        public System.String Property { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>The string identifier of the associated RestApi.</para>
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
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter Location_StatusCode
        /// <summary>
        /// <para>
        /// <para>The HTTP status code of a response. It is a valid field for the API entity types of
        /// <c>RESPONSE</c>, <c>RESPONSE_HEADER</c>, and <c>RESPONSE_BODY</c>. The default value
        /// is <c>*</c> for any status code. When an applicable child entity inherits the content
        /// of an entity of the same type with more general specifications of the other <c>location</c>
        /// attributes, the child entity's <c>statusCode</c> attribute must match that of the
        /// parent entity exactly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_StatusCode { get; set; }
        #endregion
        
        #region Parameter Location_Type
        /// <summary>
        /// <para>
        /// <para>The type of API entity to which the documentation content applies. Valid values are
        /// <c>API</c>, <c>AUTHORIZER</c>, <c>MODEL</c>, <c>RESOURCE</c>, <c>METHOD</c>, <c>PATH_PARAMETER</c>,
        /// <c>QUERY_PARAMETER</c>, <c>REQUEST_HEADER</c>, <c>REQUEST_BODY</c>, <c>RESPONSE</c>,
        /// <c>RESPONSE_HEADER</c>, and <c>RESPONSE_BODY</c>. Content inheritance does not apply
        /// to any entity of the <c>API</c>, <c>AUTHORIZER</c>, <c>METHOD</c>, <c>MODEL</c>, <c>REQUEST_BODY</c>,
        /// or <c>RESOURCE</c> type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.APIGateway.DocumentationPartType")]
        public Amazon.APIGateway.DocumentationPartType Location_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.CreateDocumentationPartResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.CreateDocumentationPartResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RestApiId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGDocumentationPart (CreateDocumentationPart)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.CreateDocumentationPartResponse, NewAGDocumentationPartCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Location_Method = this.Location_Method;
            context.Location_Name = this.Location_Name;
            context.Location_Path = this.Location_Path;
            context.Location_StatusCode = this.Location_StatusCode;
            context.Location_Type = this.Location_Type;
            #if MODULAR
            if (this.Location_Type == null && ParameterWasBound(nameof(this.Location_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Location_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Property = this.Property;
            #if MODULAR
            if (this.Property == null && ParameterWasBound(nameof(this.Property)))
            {
                WriteWarning("You are passing $null as a value for parameter Property which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RestApiId = this.RestApiId;
            #if MODULAR
            if (this.RestApiId == null && ParameterWasBound(nameof(this.RestApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter RestApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.APIGateway.Model.CreateDocumentationPartRequest();
            
            
             // populate Location
            var requestLocationIsNull = true;
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
            if (cmdletContext.Property != null)
            {
                request.Properties = cmdletContext.Property;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
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
        
        private Amazon.APIGateway.Model.CreateDocumentationPartResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateDocumentationPartRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateDocumentationPart");
            try
            {
                #if DESKTOP
                return client.CreateDocumentationPart(request);
                #elif CORECLR
                return client.CreateDocumentationPartAsync(request).GetAwaiter().GetResult();
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
            public System.String Property { get; set; }
            public System.String RestApiId { get; set; }
            public System.Func<Amazon.APIGateway.Model.CreateDocumentationPartResponse, NewAGDocumentationPartCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
