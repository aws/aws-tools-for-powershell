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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Changes an existing Amazon Redshift IAM Identity Center application.
    /// </summary>
    [Cmdlet("Edit", "RSRedshiftIdcApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.RedshiftIdcApplication")]
    [AWSCmdlet("Calls the Amazon Redshift ModifyRedshiftIdcApplication API operation.", Operation = new[] {"ModifyRedshiftIdcApplication"}, SelectReturnType = typeof(Amazon.Redshift.Model.ModifyRedshiftIdcApplicationResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.RedshiftIdcApplication or Amazon.Redshift.Model.ModifyRedshiftIdcApplicationResponse",
        "This cmdlet returns an Amazon.Redshift.Model.RedshiftIdcApplication object.",
        "The service call response (type Amazon.Redshift.Model.ModifyRedshiftIdcApplicationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRSRedshiftIdcApplicationCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthorizedTokenIssuerList
        /// <summary>
        /// <para>
        /// <para>The authorized token issuer list for the Amazon Redshift IAM Identity Center application
        /// to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Redshift.Model.AuthorizedTokenIssuer[] AuthorizedTokenIssuerList { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role ARN associated with the Amazon Redshift IAM Identity Center application
        /// to change. It has the required permissions to be assumed and invoke the IDC Identity
        /// Center API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter IdcDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name for the Amazon Redshift IAM Identity Center application to change.
        /// It appears on the console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdcDisplayName { get; set; }
        #endregion
        
        #region Parameter IdentityNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace for the Amazon Redshift IAM Identity Center application to change. It
        /// determines which managed application verifies the connection token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityNamespace { get; set; }
        #endregion
        
        #region Parameter RedshiftIdcApplicationArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the Redshift application that integrates with IAM Identity Center.</para>
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
        public System.String RedshiftIdcApplicationArn { get; set; }
        #endregion
        
        #region Parameter ServiceIntegration
        /// <summary>
        /// <para>
        /// <para>A collection of service integrations associated with the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceIntegrations")]
        public Amazon.Redshift.Model.ServiceIntegrationsUnion[] ServiceIntegration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RedshiftIdcApplication'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.ModifyRedshiftIdcApplicationResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.ModifyRedshiftIdcApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RedshiftIdcApplication";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RedshiftIdcApplicationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RedshiftIdcApplicationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RedshiftIdcApplicationArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RedshiftIdcApplicationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSRedshiftIdcApplication (ModifyRedshiftIdcApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.ModifyRedshiftIdcApplicationResponse, EditRSRedshiftIdcApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RedshiftIdcApplicationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AuthorizedTokenIssuerList != null)
            {
                context.AuthorizedTokenIssuerList = new List<Amazon.Redshift.Model.AuthorizedTokenIssuer>(this.AuthorizedTokenIssuerList);
            }
            context.IamRoleArn = this.IamRoleArn;
            context.IdcDisplayName = this.IdcDisplayName;
            context.IdentityNamespace = this.IdentityNamespace;
            context.RedshiftIdcApplicationArn = this.RedshiftIdcApplicationArn;
            #if MODULAR
            if (this.RedshiftIdcApplicationArn == null && ParameterWasBound(nameof(this.RedshiftIdcApplicationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RedshiftIdcApplicationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ServiceIntegration != null)
            {
                context.ServiceIntegration = new List<Amazon.Redshift.Model.ServiceIntegrationsUnion>(this.ServiceIntegration);
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
            var request = new Amazon.Redshift.Model.ModifyRedshiftIdcApplicationRequest();
            
            if (cmdletContext.AuthorizedTokenIssuerList != null)
            {
                request.AuthorizedTokenIssuerList = cmdletContext.AuthorizedTokenIssuerList;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.IdcDisplayName != null)
            {
                request.IdcDisplayName = cmdletContext.IdcDisplayName;
            }
            if (cmdletContext.IdentityNamespace != null)
            {
                request.IdentityNamespace = cmdletContext.IdentityNamespace;
            }
            if (cmdletContext.RedshiftIdcApplicationArn != null)
            {
                request.RedshiftIdcApplicationArn = cmdletContext.RedshiftIdcApplicationArn;
            }
            if (cmdletContext.ServiceIntegration != null)
            {
                request.ServiceIntegrations = cmdletContext.ServiceIntegration;
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
        
        private Amazon.Redshift.Model.ModifyRedshiftIdcApplicationResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.ModifyRedshiftIdcApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "ModifyRedshiftIdcApplication");
            try
            {
                #if DESKTOP
                return client.ModifyRedshiftIdcApplication(request);
                #elif CORECLR
                return client.ModifyRedshiftIdcApplicationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Redshift.Model.AuthorizedTokenIssuer> AuthorizedTokenIssuerList { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String IdcDisplayName { get; set; }
            public System.String IdentityNamespace { get; set; }
            public System.String RedshiftIdcApplicationArn { get; set; }
            public List<Amazon.Redshift.Model.ServiceIntegrationsUnion> ServiceIntegration { get; set; }
            public System.Func<Amazon.Redshift.Model.ModifyRedshiftIdcApplicationResponse, EditRSRedshiftIdcApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RedshiftIdcApplication;
        }
        
    }
}
