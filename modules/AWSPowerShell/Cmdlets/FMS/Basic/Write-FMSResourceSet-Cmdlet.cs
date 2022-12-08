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
using Amazon.FMS;
using Amazon.FMS.Model;

namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Creates the resource set.
    /// 
    ///  
    /// <para>
    /// An Firewall Manager resource set defines the resources to import into an Firewall
    /// Manager policy from another Amazon Web Services service.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "FMSResourceSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FMS.Model.PutResourceSetResponse")]
    [AWSCmdlet("Calls the Firewall Management Service PutResourceSet API operation.", Operation = new[] {"PutResourceSet"}, SelectReturnType = typeof(Amazon.FMS.Model.PutResourceSetResponse))]
    [AWSCmdletOutput("Amazon.FMS.Model.PutResourceSetResponse",
        "This cmdlet returns an Amazon.FMS.Model.PutResourceSetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteFMSResourceSetCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceSet_Description
        /// <summary>
        /// <para>
        /// <para>A description of the resource set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceSet_Description { get; set; }
        #endregion
        
        #region Parameter ResourceSet_Id
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the resource set. This ID is returned in the responses to
        /// create and list commands. You provide it to operations like update and delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceSet_Id { get; set; }
        #endregion
        
        #region Parameter ResourceSet_LastUpdateTime
        /// <summary>
        /// <para>
        /// <para>The last time that the resource set was changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ResourceSet_LastUpdateTime { get; set; }
        #endregion
        
        #region Parameter ResourceSet_Name
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the resource set. You can't change the name of a resource
        /// set after you create it.</para>
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
        public System.String ResourceSet_Name { get; set; }
        #endregion
        
        #region Parameter ResourceSet_ResourceTypeList
        /// <summary>
        /// <para>
        /// <para>Determines the resources that can be associated to the resource set. Depending on
        /// your setting for max results and the number of resource sets, a single call might
        /// not return the full list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] ResourceSet_ResourceTypeList { get; set; }
        #endregion
        
        #region Parameter TagList
        /// <summary>
        /// <para>
        /// <para>Retrieves the tags associated with the specified resource set. Tags are key:value
        /// pairs that you can use to categorize and manage your resources, for purposes like
        /// billing. For example, you might set the tag key to "customer" and the value to the
        /// customer name or ID. You can specify one or more tags to add to each Amazon Web Services
        /// resource, up to 50 tags for a resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.FMS.Model.Tag[] TagList { get; set; }
        #endregion
        
        #region Parameter ResourceSet_UpdateToken
        /// <summary>
        /// <para>
        /// <para>An optional token that you can use for optimistic locking. Firewall Manager returns
        /// a token to your requests that access the resource set. The token marks the state of
        /// the resource set resource at the time of the request. Update tokens are not allowed
        /// when creating a resource set. After creation, each subsequent update call to the resource
        /// set requires the update token. </para><para>To make an unconditional change to the resource set, omit the token in your update
        /// request. Without the token, Firewall Manager performs your updates regardless of whether
        /// the resource set has changed since you last retrieved it.</para><para>To make a conditional change to the resource set, provide the token in your update
        /// request. Firewall Manager uses the token to ensure that the resource set hasn't changed
        /// since you last retrieved it. If it has changed, the operation fails with an <code>InvalidTokenException</code>.
        /// If this happens, retrieve the resource set again to get a current copy of it with
        /// a new token. Reapply your changes as needed, then try the operation again using the
        /// new token. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceSet_UpdateToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FMS.Model.PutResourceSetResponse).
        /// Specifying the name of a property of type Amazon.FMS.Model.PutResourceSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceSet_Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceSet_Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceSet_Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceSet_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-FMSResourceSet (PutResourceSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FMS.Model.PutResourceSetResponse, WriteFMSResourceSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceSet_Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceSet_Description = this.ResourceSet_Description;
            context.ResourceSet_Id = this.ResourceSet_Id;
            context.ResourceSet_LastUpdateTime = this.ResourceSet_LastUpdateTime;
            context.ResourceSet_Name = this.ResourceSet_Name;
            #if MODULAR
            if (this.ResourceSet_Name == null && ParameterWasBound(nameof(this.ResourceSet_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceSet_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceSet_ResourceTypeList != null)
            {
                context.ResourceSet_ResourceTypeList = new List<System.String>(this.ResourceSet_ResourceTypeList);
            }
            #if MODULAR
            if (this.ResourceSet_ResourceTypeList == null && ParameterWasBound(nameof(this.ResourceSet_ResourceTypeList)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceSet_ResourceTypeList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceSet_UpdateToken = this.ResourceSet_UpdateToken;
            if (this.TagList != null)
            {
                context.TagList = new List<Amazon.FMS.Model.Tag>(this.TagList);
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
            var request = new Amazon.FMS.Model.PutResourceSetRequest();
            
            
             // populate ResourceSet
            var requestResourceSetIsNull = true;
            request.ResourceSet = new Amazon.FMS.Model.ResourceSet();
            System.String requestResourceSet_resourceSet_Description = null;
            if (cmdletContext.ResourceSet_Description != null)
            {
                requestResourceSet_resourceSet_Description = cmdletContext.ResourceSet_Description;
            }
            if (requestResourceSet_resourceSet_Description != null)
            {
                request.ResourceSet.Description = requestResourceSet_resourceSet_Description;
                requestResourceSetIsNull = false;
            }
            System.String requestResourceSet_resourceSet_Id = null;
            if (cmdletContext.ResourceSet_Id != null)
            {
                requestResourceSet_resourceSet_Id = cmdletContext.ResourceSet_Id;
            }
            if (requestResourceSet_resourceSet_Id != null)
            {
                request.ResourceSet.Id = requestResourceSet_resourceSet_Id;
                requestResourceSetIsNull = false;
            }
            System.DateTime? requestResourceSet_resourceSet_LastUpdateTime = null;
            if (cmdletContext.ResourceSet_LastUpdateTime != null)
            {
                requestResourceSet_resourceSet_LastUpdateTime = cmdletContext.ResourceSet_LastUpdateTime.Value;
            }
            if (requestResourceSet_resourceSet_LastUpdateTime != null)
            {
                request.ResourceSet.LastUpdateTime = requestResourceSet_resourceSet_LastUpdateTime.Value;
                requestResourceSetIsNull = false;
            }
            System.String requestResourceSet_resourceSet_Name = null;
            if (cmdletContext.ResourceSet_Name != null)
            {
                requestResourceSet_resourceSet_Name = cmdletContext.ResourceSet_Name;
            }
            if (requestResourceSet_resourceSet_Name != null)
            {
                request.ResourceSet.Name = requestResourceSet_resourceSet_Name;
                requestResourceSetIsNull = false;
            }
            List<System.String> requestResourceSet_resourceSet_ResourceTypeList = null;
            if (cmdletContext.ResourceSet_ResourceTypeList != null)
            {
                requestResourceSet_resourceSet_ResourceTypeList = cmdletContext.ResourceSet_ResourceTypeList;
            }
            if (requestResourceSet_resourceSet_ResourceTypeList != null)
            {
                request.ResourceSet.ResourceTypeList = requestResourceSet_resourceSet_ResourceTypeList;
                requestResourceSetIsNull = false;
            }
            System.String requestResourceSet_resourceSet_UpdateToken = null;
            if (cmdletContext.ResourceSet_UpdateToken != null)
            {
                requestResourceSet_resourceSet_UpdateToken = cmdletContext.ResourceSet_UpdateToken;
            }
            if (requestResourceSet_resourceSet_UpdateToken != null)
            {
                request.ResourceSet.UpdateToken = requestResourceSet_resourceSet_UpdateToken;
                requestResourceSetIsNull = false;
            }
             // determine if request.ResourceSet should be set to null
            if (requestResourceSetIsNull)
            {
                request.ResourceSet = null;
            }
            if (cmdletContext.TagList != null)
            {
                request.TagList = cmdletContext.TagList;
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
        
        private Amazon.FMS.Model.PutResourceSetResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.PutResourceSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "PutResourceSet");
            try
            {
                #if DESKTOP
                return client.PutResourceSet(request);
                #elif CORECLR
                return client.PutResourceSetAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceSet_Description { get; set; }
            public System.String ResourceSet_Id { get; set; }
            public System.DateTime? ResourceSet_LastUpdateTime { get; set; }
            public System.String ResourceSet_Name { get; set; }
            public List<System.String> ResourceSet_ResourceTypeList { get; set; }
            public System.String ResourceSet_UpdateToken { get; set; }
            public List<Amazon.FMS.Model.Tag> TagList { get; set; }
            public System.Func<Amazon.FMS.Model.PutResourceSetResponse, WriteFMSResourceSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
