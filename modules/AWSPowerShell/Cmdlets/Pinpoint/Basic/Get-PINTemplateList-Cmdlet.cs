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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Retrieves information about all the message templates that are associated with your
    /// Amazon Pinpoint account.
    /// </summary>
    [Cmdlet("Get", "PINTemplateList")]
    [OutputType("Amazon.Pinpoint.Model.TemplatesResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint ListTemplates API operation.", Operation = new[] {"ListTemplates"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.ListTemplatesResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.TemplatesResponse or Amazon.Pinpoint.Model.ListTemplatesResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.TemplatesResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.ListTemplatesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPINTemplateListCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// <para>The substring to match in the names of the message templates to include in the results.
        /// If you specify this value, Amazon Pinpoint returns only those templates whose names
        /// begin with the value that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Prefix { get; set; }
        #endregion
        
        #region Parameter TemplateType
        /// <summary>
        /// <para>
        /// <para>The type of message template to include in the results. Valid values are: EMAIL, PUSH,
        /// SMS, and VOICE. To include all types of templates in the results, don't include this
        /// parameter in your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateType { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The  string that specifies which page of results to return in a paginated response.
        /// This parameter is not supported for application, campaign, and journey metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to include in each page of a paginated response. This
        /// parameter is not supported for application, campaign, and journey metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TemplatesResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.ListTemplatesResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.ListTemplatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TemplatesResponse";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Prefix parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Prefix' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Prefix' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.ListTemplatesResponse, GetPINTemplateListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Prefix;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NextToken = this.NextToken;
            context.PageSize = this.PageSize;
            context.Prefix = this.Prefix;
            context.TemplateType = this.TemplateType;
            
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
            var request = new Amazon.Pinpoint.Model.ListTemplatesRequest();
            
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize;
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            if (cmdletContext.TemplateType != null)
            {
                request.TemplateType = cmdletContext.TemplateType;
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
        
        private Amazon.Pinpoint.Model.ListTemplatesResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.ListTemplatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "ListTemplates");
            try
            {
                #if DESKTOP
                return client.ListTemplates(request);
                #elif CORECLR
                return client.ListTemplatesAsync(request).GetAwaiter().GetResult();
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
            public System.String NextToken { get; set; }
            public System.String PageSize { get; set; }
            public System.String Prefix { get; set; }
            public System.String TemplateType { get; set; }
            public System.Func<Amazon.Pinpoint.Model.ListTemplatesResponse, GetPINTemplateListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TemplatesResponse;
        }
        
    }
}
