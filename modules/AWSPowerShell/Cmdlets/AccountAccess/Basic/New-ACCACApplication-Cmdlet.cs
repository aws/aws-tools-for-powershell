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
using Amazon.AccountAccess;
using Amazon.AccountAccess.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ACCAC
{
    /// <summary>
    /// Creates an account access manager instance and its Amazon Web Services account access
    /// application in the associated IAM Identity Center instance. This operation is idempotent;
    /// calling it multiple times with the same parameters returns the existing application.
    /// </summary>
    [Cmdlet("New", "ACCACApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Account Access CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.AccountAccess.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("System.String or Amazon.AccountAccess.Model.CreateApplicationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AccountAccess.Model.CreateApplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewACCACApplicationCmdlet : AmazonAccountAccessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IdentitySource_IdentityCenter_InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM Identity Center instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String IdentitySource_IdentityCenter_InstanceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies the tags to assign to the application.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AccountAccess.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.AccountAccess.Model.CreateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentitySource_IdentityCenter_InstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ACCACApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AccountAccess.Model.CreateApplicationResponse, NewACCACApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdentitySource_IdentityCenter_InstanceArn = this.IdentitySource_IdentityCenter_InstanceArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.AccountAccess.Model.CreateApplicationRequest();
            
            
             // populate IdentitySource
            var requestIdentitySourceIsNull = true;
            request.IdentitySource = new Amazon.AccountAccess.Model.IdentitySource();
            Amazon.AccountAccess.Model.IdentityCenter requestIdentitySource_identitySource_IdentityCenter = null;
            
             // populate IdentityCenter
            var requestIdentitySource_identitySource_IdentityCenterIsNull = true;
            requestIdentitySource_identitySource_IdentityCenter = new Amazon.AccountAccess.Model.IdentityCenter();
            System.String requestIdentitySource_identitySource_IdentityCenter_identitySource_IdentityCenter_InstanceArn = null;
            if (cmdletContext.IdentitySource_IdentityCenter_InstanceArn != null)
            {
                requestIdentitySource_identitySource_IdentityCenter_identitySource_IdentityCenter_InstanceArn = cmdletContext.IdentitySource_IdentityCenter_InstanceArn;
            }
            if (requestIdentitySource_identitySource_IdentityCenter_identitySource_IdentityCenter_InstanceArn != null)
            {
                requestIdentitySource_identitySource_IdentityCenter.InstanceArn = requestIdentitySource_identitySource_IdentityCenter_identitySource_IdentityCenter_InstanceArn;
                requestIdentitySource_identitySource_IdentityCenterIsNull = false;
            }
             // determine if requestIdentitySource_identitySource_IdentityCenter should be set to null
            if (requestIdentitySource_identitySource_IdentityCenterIsNull)
            {
                requestIdentitySource_identitySource_IdentityCenter = null;
            }
            if (requestIdentitySource_identitySource_IdentityCenter != null)
            {
                request.IdentitySource.IdentityCenter = requestIdentitySource_identitySource_IdentityCenter;
                requestIdentitySourceIsNull = false;
            }
             // determine if request.IdentitySource should be set to null
            if (requestIdentitySourceIsNull)
            {
                request.IdentitySource = null;
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
        
        private Amazon.AccountAccess.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonAccountAccess client, Amazon.AccountAccess.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Account Access", "CreateApplication");
            try
            {
                return client.CreateApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IdentitySource_IdentityCenter_InstanceArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AccountAccess.Model.CreateApplicationResponse, NewACCACApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationArn;
        }
        
    }
}
