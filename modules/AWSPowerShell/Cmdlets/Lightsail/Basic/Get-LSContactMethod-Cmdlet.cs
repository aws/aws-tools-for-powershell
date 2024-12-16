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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns information about the configured contact methods. Specify a protocol in your
    /// request to return information about a specific contact method.
    /// 
    ///  
    /// <para>
    /// A contact method is used to send you notifications about your Amazon Lightsail resources.
    /// You can add one email address and one mobile phone number contact method in each Amazon
    /// Web Services Region. However, SMS text messaging is not supported in some Amazon Web
    /// Services Regions, and SMS text messages cannot be sent to some countries/regions.
    /// For more information, see <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-notifications">Notifications
    /// in Amazon Lightsail</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LSContactMethod")]
    [OutputType("Amazon.Lightsail.Model.ContactMethod")]
    [AWSCmdlet("Calls the Amazon Lightsail GetContactMethods API operation.", Operation = new[] {"GetContactMethods"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetContactMethodsResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.ContactMethod or Amazon.Lightsail.Model.GetContactMethodsResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.ContactMethod objects.",
        "The service call response (type Amazon.Lightsail.Model.GetContactMethodsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLSContactMethodCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocols used to send notifications, such as <c>Email</c>, or <c>SMS</c> (text
        /// messaging).</para><para>Specify a protocol in your request to return information about a specific contact
        /// method protocol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocols")]
        public System.String[] Protocol { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContactMethods'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetContactMethodsResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetContactMethodsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContactMethods";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetContactMethodsResponse, GetLSContactMethodCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Protocol != null)
            {
                context.Protocol = new List<System.String>(this.Protocol);
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
            var request = new Amazon.Lightsail.Model.GetContactMethodsRequest();
            
            if (cmdletContext.Protocol != null)
            {
                request.Protocols = cmdletContext.Protocol;
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
        
        private Amazon.Lightsail.Model.GetContactMethodsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetContactMethodsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetContactMethods");
            try
            {
                #if DESKTOP
                return client.GetContactMethods(request);
                #elif CORECLR
                return client.GetContactMethodsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Protocol { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetContactMethodsResponse, GetLSContactMethodCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContactMethods;
        }
        
    }
}
