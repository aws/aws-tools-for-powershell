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
using Amazon.Amplify;
using Amazon.Amplify.Model;

namespace Amazon.PowerShell.Cmdlets.AMP
{
    /// <summary>
    /// Create a new DomainAssociation on an App
    /// </summary>
    [Cmdlet("New", "AMPDomainAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Amplify.Model.DomainAssociation")]
    [AWSCmdlet("Calls the AWS Amplify CreateDomainAssociation API operation.", Operation = new[] {"CreateDomainAssociation"})]
    [AWSCmdletOutput("Amazon.Amplify.Model.DomainAssociation",
        "This cmdlet returns a DomainAssociation object.",
        "The service call response (type Amazon.Amplify.Model.CreateDomainAssociationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMPDomainAssociationCmdlet : AmazonAmplifyClientCmdlet, IExecutor
    {
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para> Unique Id for an Amplify App. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para> Domain name for the Domain Association. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter EnableAutoSubDomain
        /// <summary>
        /// <para>
        /// <para> Enables automated creation of Subdomains for branches. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableAutoSubDomain { get; set; }
        #endregion
        
        #region Parameter SubDomainSetting
        /// <summary>
        /// <para>
        /// <para> Setting structure for the Subdomain. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SubDomainSettings")]
        public Amazon.Amplify.Model.SubDomainSetting[] SubDomainSetting { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPDomainAssociation (CreateDomainAssociation)"))
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
            
            context.AppId = this.AppId;
            context.DomainName = this.DomainName;
            if (ParameterWasBound("EnableAutoSubDomain"))
                context.EnableAutoSubDomain = this.EnableAutoSubDomain;
            if (this.SubDomainSetting != null)
            {
                context.SubDomainSettings = new List<Amazon.Amplify.Model.SubDomainSetting>(this.SubDomainSetting);
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
            var request = new Amazon.Amplify.Model.CreateDomainAssociationRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.EnableAutoSubDomain != null)
            {
                request.EnableAutoSubDomain = cmdletContext.EnableAutoSubDomain.Value;
            }
            if (cmdletContext.SubDomainSettings != null)
            {
                request.SubDomainSettings = cmdletContext.SubDomainSettings;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DomainAssociation;
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
        
        private Amazon.Amplify.Model.CreateDomainAssociationResponse CallAWSServiceOperation(IAmazonAmplify client, Amazon.Amplify.Model.CreateDomainAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify", "CreateDomainAssociation");
            try
            {
                #if DESKTOP
                return client.CreateDomainAssociation(request);
                #elif CORECLR
                return client.CreateDomainAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String DomainName { get; set; }
            public System.Boolean? EnableAutoSubDomain { get; set; }
            public List<Amazon.Amplify.Model.SubDomainSetting> SubDomainSettings { get; set; }
        }
        
    }
}
