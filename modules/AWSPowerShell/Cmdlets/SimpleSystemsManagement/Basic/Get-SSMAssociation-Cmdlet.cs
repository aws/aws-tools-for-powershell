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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Describes the association for the specified target or managed node. If you created
    /// the association by using the <c>Targets</c> parameter, then you must retrieve the
    /// association by using the association ID.
    /// </summary>
    [Cmdlet("Get", "SSMAssociation")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.AssociationDescription")]
    [AWSCmdlet("Calls the AWS Systems Manager DescribeAssociation API operation.", Operation = new[] {"DescribeAssociation"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.DescribeAssociationResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.AssociationDescription or Amazon.SimpleSystemsManagement.Model.DescribeAssociationResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.AssociationDescription object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.DescribeAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSMAssociationCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociationId
        /// <summary>
        /// <para>
        /// <para>The association ID for which you want information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssociationId { get; set; }
        #endregion
        
        #region Parameter AssociationVersion
        /// <summary>
        /// <para>
        /// <para>Specify the association version to retrieve. To view the latest version, either specify
        /// <c>$LATEST</c> for this parameter, or omit this parameter. To view a list of all associations
        /// for a managed node, use <a>ListAssociations</a>. To get a list of versions for a specific
        /// association, use <a>ListAssociationVersions</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssociationVersion { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The managed node ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the SSM document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssociationDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.DescribeAssociationResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.DescribeAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssociationDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.DescribeAssociationResponse, GetSSMAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssociationId = this.AssociationId;
            context.AssociationVersion = this.AssociationVersion;
            context.InstanceId = this.InstanceId;
            context.Name = this.Name;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.DescribeAssociationRequest();
            
            if (cmdletContext.AssociationId != null)
            {
                request.AssociationId = cmdletContext.AssociationId;
            }
            if (cmdletContext.AssociationVersion != null)
            {
                request.AssociationVersion = cmdletContext.AssociationVersion;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.SimpleSystemsManagement.Model.DescribeAssociationResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.DescribeAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "DescribeAssociation");
            try
            {
                #if DESKTOP
                return client.DescribeAssociation(request);
                #elif CORECLR
                return client.DescribeAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociationId { get; set; }
            public System.String AssociationVersion { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.DescribeAssociationResponse, GetSSMAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssociationDescription;
        }
        
    }
}
