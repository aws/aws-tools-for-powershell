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
using System.Threading;
using Amazon.Redshift;
using Amazon.Redshift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Creates an Amazon Redshift application for use with IAM Identity Center.
    /// </summary>
    [Cmdlet("New", "RSRedshiftIdcApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.RedshiftIdcApplication")]
    [AWSCmdlet("Calls the Amazon Redshift CreateRedshiftIdcApplication API operation.", Operation = new[] {"CreateRedshiftIdcApplication"}, SelectReturnType = typeof(Amazon.Redshift.Model.CreateRedshiftIdcApplicationResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.RedshiftIdcApplication or Amazon.Redshift.Model.CreateRedshiftIdcApplicationResponse",
        "This cmdlet returns an Amazon.Redshift.Model.RedshiftIdcApplication object.",
        "The service call response (type Amazon.Redshift.Model.CreateRedshiftIdcApplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRSRedshiftIdcApplicationCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationType
        /// <summary>
        /// <para>
        /// <para>The type of application being created. Valid values are <c>None</c> or <c>Lakehouse</c>.
        /// Use <c>Lakehouse</c> to enable Amazon Redshift federated permissions on cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Redshift.ApplicationType")]
        public Amazon.Redshift.ApplicationType ApplicationType { get; set; }
        #endregion
        
        #region Parameter AuthorizedTokenIssuerList
        /// <summary>
        /// <para>
        /// <para>The token issuer list for the Amazon Redshift IAM Identity Center application instance.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Redshift.Model.AuthorizedTokenIssuer[] AuthorizedTokenIssuerList { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role ARN for the Amazon Redshift IAM Identity Center application instance.
        /// It has the required permissions to be assumed and invoke the IDC Identity Center API.</para>
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
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter IdcDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name for the Amazon Redshift IAM Identity Center application instance.
        /// It appears in the console.</para>
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
        public System.String IdcDisplayName { get; set; }
        #endregion
        
        #region Parameter IdcInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon resource name (ARN) of the IAM Identity Center instance where Amazon Redshift
        /// creates a new managed application.</para>
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
        public System.String IdcInstanceArn { get; set; }
        #endregion
        
        #region Parameter IdentityNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace for the Amazon Redshift IAM Identity Center application instance. It
        /// determines which managed application verifies the connection token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityNamespace { get; set; }
        #endregion
        
        #region Parameter RedshiftIdcApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the Redshift application in IAM Identity Center.</para>
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
        public System.String RedshiftIdcApplicationName { get; set; }
        #endregion
        
        #region Parameter ServiceIntegration
        /// <summary>
        /// <para>
        /// <para>A collection of service integrations for the Redshift IAM Identity Center application.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceIntegrations")]
        public Amazon.Redshift.Model.ServiceIntegrationsUnion[] ServiceIntegration { get; set; }
        #endregion
        
        #region Parameter SsoTagKey
        /// <summary>
        /// <para>
        /// <para>A list of tags keys that Redshift Identity Center applications copy to IAM Identity
        /// Center. For each input key, the tag corresponding to the key-value pair is propagated.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SsoTagKeys")]
        public System.String[] SsoTagKey { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RedshiftIdcApplication'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.CreateRedshiftIdcApplicationResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.CreateRedshiftIdcApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RedshiftIdcApplication";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdcInstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSRedshiftIdcApplication (CreateRedshiftIdcApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.CreateRedshiftIdcApplicationResponse, NewRSRedshiftIdcApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationType = this.ApplicationType;
            if (this.AuthorizedTokenIssuerList != null)
            {
                context.AuthorizedTokenIssuerList = new List<Amazon.Redshift.Model.AuthorizedTokenIssuer>(this.AuthorizedTokenIssuerList);
            }
            context.IamRoleArn = this.IamRoleArn;
            #if MODULAR
            if (this.IamRoleArn == null && ParameterWasBound(nameof(this.IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdcDisplayName = this.IdcDisplayName;
            #if MODULAR
            if (this.IdcDisplayName == null && ParameterWasBound(nameof(this.IdcDisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter IdcDisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdcInstanceArn = this.IdcInstanceArn;
            #if MODULAR
            if (this.IdcInstanceArn == null && ParameterWasBound(nameof(this.IdcInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IdcInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityNamespace = this.IdentityNamespace;
            context.RedshiftIdcApplicationName = this.RedshiftIdcApplicationName;
            #if MODULAR
            if (this.RedshiftIdcApplicationName == null && ParameterWasBound(nameof(this.RedshiftIdcApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter RedshiftIdcApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ServiceIntegration != null)
            {
                context.ServiceIntegration = new List<Amazon.Redshift.Model.ServiceIntegrationsUnion>(this.ServiceIntegration);
            }
            if (this.SsoTagKey != null)
            {
                context.SsoTagKey = new List<System.String>(this.SsoTagKey);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Redshift.Model.Tag>(this.Tag);
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
            var request = new Amazon.Redshift.Model.CreateRedshiftIdcApplicationRequest();
            
            if (cmdletContext.ApplicationType != null)
            {
                request.ApplicationType = cmdletContext.ApplicationType;
            }
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
            if (cmdletContext.IdcInstanceArn != null)
            {
                request.IdcInstanceArn = cmdletContext.IdcInstanceArn;
            }
            if (cmdletContext.IdentityNamespace != null)
            {
                request.IdentityNamespace = cmdletContext.IdentityNamespace;
            }
            if (cmdletContext.RedshiftIdcApplicationName != null)
            {
                request.RedshiftIdcApplicationName = cmdletContext.RedshiftIdcApplicationName;
            }
            if (cmdletContext.ServiceIntegration != null)
            {
                request.ServiceIntegrations = cmdletContext.ServiceIntegration;
            }
            if (cmdletContext.SsoTagKey != null)
            {
                request.SsoTagKeys = cmdletContext.SsoTagKey;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Redshift.Model.CreateRedshiftIdcApplicationResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CreateRedshiftIdcApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CreateRedshiftIdcApplication");
            try
            {
                return client.CreateRedshiftIdcApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Redshift.ApplicationType ApplicationType { get; set; }
            public List<Amazon.Redshift.Model.AuthorizedTokenIssuer> AuthorizedTokenIssuerList { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String IdcDisplayName { get; set; }
            public System.String IdcInstanceArn { get; set; }
            public System.String IdentityNamespace { get; set; }
            public System.String RedshiftIdcApplicationName { get; set; }
            public List<Amazon.Redshift.Model.ServiceIntegrationsUnion> ServiceIntegration { get; set; }
            public List<System.String> SsoTagKey { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Redshift.Model.CreateRedshiftIdcApplicationResponse, NewRSRedshiftIdcApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RedshiftIdcApplication;
        }
        
    }
}
