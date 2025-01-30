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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Lists all contacts and escalation plans in Incident Manager.
    /// </summary>
    [Cmdlet("Get", "SMCContactList")]
    [OutputType("Amazon.SSMContacts.Model.Contact")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager Contacts ListContacts API operation.", Operation = new[] {"ListContacts"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.ListContactsResponse))]
    [AWSCmdletOutput("Amazon.SSMContacts.Model.Contact or Amazon.SSMContacts.Model.ListContactsResponse",
        "This cmdlet returns a collection of Amazon.SSMContacts.Model.Contact objects.",
        "The service call response (type Amazon.SSMContacts.Model.ListContactsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMCContactListCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AliasPrefix
        /// <summary>
        /// <para>
        /// <para>Used to list only contacts who's aliases start with the specified prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AliasPrefix { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of contact. A contact is type <c>PERSONAL</c> and an escalation plan is type
        /// <c>ESCALATION</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.SSMContacts.ContactType")]
        public Amazon.SSMContacts.ContactType Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of contacts and escalation plans per page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token to continue to the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Contacts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.ListContactsResponse).
        /// Specifying the name of a property of type Amazon.SSMContacts.Model.ListContactsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Contacts";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Type parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Type' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Type' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.ListContactsResponse, GetSMCContactListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Type;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AliasPrefix = this.AliasPrefix;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Type = this.Type;
            
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
            var request = new Amazon.SSMContacts.Model.ListContactsRequest();
            
            if (cmdletContext.AliasPrefix != null)
            {
                request.AliasPrefix = cmdletContext.AliasPrefix;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.SSMContacts.Model.ListContactsResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.ListContactsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager Contacts", "ListContacts");
            try
            {
                #if DESKTOP
                return client.ListContacts(request);
                #elif CORECLR
                return client.ListContactsAsync(request).GetAwaiter().GetResult();
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
            public System.String AliasPrefix { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.SSMContacts.ContactType Type { get; set; }
            public System.Func<Amazon.SSMContacts.Model.ListContactsResponse, GetSMCContactListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Contacts;
        }
        
    }
}
